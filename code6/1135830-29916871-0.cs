    public sealed class VariableList<T> : AVariableList<T>
        {
            [XmlElement("Item")]
            public new ItemList<T> Items { get { return _items; } set { _items = value; } }
            public new bool IsNull { get { return Items == null; } }
            public new bool IsEmpty { get { return IsNull || Count <= 0; } }
            public new int Count { get { return IsNull ? 0 : this.Items.Count; } }
            public new string CountAsString { get { return Count.ToString(); } }
            public VariableList()
            {
                _items = new ItemList<T>();
            }
        }
