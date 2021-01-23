        using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics;
    public class MyComboBox : System.Windows.Forms.ComboBox
    {
        public event EventHandler ItemAdded;
        //public event EventHandler ItemsAdded;
        public event EventHandler ItemRemoved;
        public event ItemInsertedEventHandler ItemInserted;
        public delegate void ItemInsertedEventHandler(object sender, int insertedIndex, EventArgs e);
        private ItemContainer ItemContainer_;
        public MyComboBox()
        {
            ItemContainer_ = new ItemContainer(this);
            ItemContainer_.ItemAdded += ItemContainer_ItemAdded;
            //ItemContainer_.ItemsAdded += ItemContainer_ItemsAdded;
            ItemContainer_.ItemRemoved += ItemContainer_ItemRemoved;
            ItemContainer_.ItemInserted += ItemContainer_ItemInserted;
        }
        private void ItemContainer_ItemAdded(object sender, EventArgs e)
        {
            if (ItemAdded != null)
            {
                ItemAdded(this, e);
            }
        }
        /*private void ItemContainer_ItemsAdded(object sender, EventArgs e)
        {
            if (ItemsAdded != null)
            {
                ItemsAdded(this, e);
            }
        }*/
        private void ItemContainer_ItemRemoved(object sender, EventArgs e)
        {
            if (ItemRemoved != null)
            {
                ItemRemoved(this, e);
            }
        }
        private void ItemContainer_ItemInserted(object sender, int insertedIndex, EventArgs e)
        {
            if (ItemInserted != null)
            {
                ItemInserted(this, insertedIndex, e);
            }
        }
        public new ItemContainer Items
        {
            get { return ItemContainer_; }
        }
        public class ItemContainer : System.Windows.Forms.ComboBox.ObjectCollection
        {
            public event EventHandler ItemAdded;
            //public event EventHandler ItemsAdded;
            public event EventHandler ItemRemoved;
            public event ItemInsertedEventHandler ItemInserted;
            public delegate void ItemInsertedEventHandler(object sender, int insertedIndex, EventArgs e);
            private System.Windows.Forms.ComboBox owner_;
            public ItemContainer(System.Windows.Forms.ComboBox owner)
                : base(owner)
            {
                owner_ = owner;
            }
            public new void Add(object item)
            {
                owner_.Items.Add(item);
                if (ItemAdded != null)
                {
                    ItemAdded(this, new EventArgs());
                }
            }
            public new void AddRange(object[] item)
            {
                owner_.Items.AddRange(item);
                /*if (ItemsAdded != null)
                {
                    ItemsAdded(this, new EventArgs());
                }*/
                if (ItemAdded != null)
                {
                    ItemAdded(this, new EventArgs());
                }
            }
            public new void Insert(int index, object item)
            {
                owner_.Items.Insert(index, item);
                if (ItemInserted != null)
                {
                    ItemInserted(this, index, new EventArgs());
                }
            }
            public new void Remove(object item)
            {
                owner_.Items.Remove(item);
                if (ItemRemoved != null)
                {
                    ItemRemoved(this, new EventArgs());
                }
            }
            public new void RemoveAt(int index)
            {
                owner_.Items.RemoveAt(index);
                if (ItemRemoved != null)
                {
                    ItemRemoved(this, new EventArgs());
                }
            }
            public new void Clear()
            {
                owner_.Items.Clear();
                if (ItemRemoved != null)
                {
                    ItemRemoved(this, new EventArgs());
                }
            }
            public new int IndexOf(object value)
            {
                return owner_.Items.IndexOf(value);
            }
            public new bool Contains(object value)
            {
                return owner_.Items.Contains(value);
            }
            public new int GetHashCode()
            {
                return owner_.Items.GetHashCode();
            }
            public new string ToString()
            {
                return owner_.Items.ToString();
            }
            public new System.Collections.IEnumerator GetEnumerator()
            {
                return owner_.Items.GetEnumerator();
            }
            public new bool Equals(object obj)
            {
                return owner_.Items.Equals(obj);
            }
            public new bool Equals(object objA, object objB)
            {
                return object.Equals(objA, objB);
            }
            public new void CopyTo(object[] Destination, int arrayIndex)
            {
                owner_.Items.CopyTo(Destination, arrayIndex);
            }
            public new int Count
            {
                get { return owner_.Items.Count; }
            }
            public new object this[int index]
            {
                get { return owner_.Items[index]; }
            }
            public new bool IsReadOnly
            {
                get { return owner_.Items.IsReadOnly; }
            }
            
        }
    }
