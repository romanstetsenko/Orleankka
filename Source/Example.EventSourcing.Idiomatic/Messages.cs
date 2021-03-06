﻿using System;
using System.Linq;

using Orleankka.Meta;

namespace Example
{
    [Serializable]
    public class Create : Command<InventoryItem>
    {
        public readonly string Name;

        public Create(string name)
        {
            Name = name;
        }
    }

    [Serializable]
    public class CheckIn : Command<InventoryItem>
    {
        public readonly int Quantity;

        public CheckIn(int quantity)
        {
            Quantity = quantity;
        }
    }

    [Serializable]
    public class CheckOut : Command<InventoryItem>
    {
        public readonly int Quantity;

        public CheckOut(int quantity)
        {
            Quantity = quantity;
        }
    }

    [Serializable]
    public class Rename : Command<InventoryItem>
    {
        public readonly string NewName;

        public Rename(string newName)
        {
            NewName = newName;
        }
    }

    [Serializable]
    public class Deactivate : Command<InventoryItem>
    {}

    [Serializable]
    public class GetDetails : Query<InventoryItem, InventoryItemDetails>
    {}

    [Serializable]
    public class GetInventoryItems : Query<Inventory, InventoryItemDetails[]>
    {}

    [Serializable]
    public class GetInventoryItemsTotal : Query<Inventory, int>
    {}

    [Serializable]
    public class EventEnvelope<T> where T : Event
    {
        public readonly string Stream;
        public readonly T Event;

        public EventEnvelope(string stream, T @event)
        {
            Stream = stream;
            Event = @event;
        }
    }

    [Serializable]
    public class InventoryItemDetails
    {
        public string Name;
        public int Total;
        public bool Active;

        public InventoryItemDetails(string name, int total, bool active)
        {
            Name = name;
            Total = total;
            Active = active;
        }
    }

    [Serializable]
    public class InventoryItemCreated : Event
    {
        public readonly string Name;

        public InventoryItemCreated(string name)
        {
            Name = name;
        }
    }

    [Serializable]
    public class InventoryItemCheckedIn : Event
    {
        public readonly int Quantity;

        public InventoryItemCheckedIn(int quantity)
        {
            Quantity = quantity;
        }
    }

    [Serializable]
    public class InventoryItemCheckedOut : Event
    {
        public readonly int Quantity;

        public InventoryItemCheckedOut(int quantity)
        {
            Quantity = quantity;
        }
    }

    [Serializable]
    public class InventoryItemRenamed : Event
    {
        public readonly string OldName;
        public readonly string NewName;

        public InventoryItemRenamed(string oldName, string newName)
        {
            OldName = oldName;
            NewName = newName;
        }
    }

    [Serializable]
    public class InventoryItemDeactivated : Event
    {}
}
