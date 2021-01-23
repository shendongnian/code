    [DataContract]
    public class Inventory
    {
        public Inventory()
        {
            Items = new Dictionary<Item, int>();
        }
        [IgnoreDataMember]
        public Dictionary<Item, int> Items { get; set; }
        [DataMember(Name = "Items")]
        public KeyValuePair<Item, int> [] ItemArray
        {
            get
            {
                return Items == null ? null : Items.ToArray();
            }
            set
            {
                (Items ?? (Items = new Dictionary<Item, int>())).Clear();
                if (value != null)
                    foreach (var pair in value)
                        Items[pair.Key] = pair.Value;
            }
        }
    }
