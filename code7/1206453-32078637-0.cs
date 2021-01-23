    [JsonObject(MemberSerialization = MemberSerialization.OptIn)] // OptIn to omit the properties of the base class,  e.g. Count
    class Group<K, T> : ObservableCollection<T>
    {
        [JsonProperty("Header")]
        public K Key { get; set; }
        [JsonProperty("Items")]
        IEnumerable<T> Values
        {
            get
            {
                foreach (var item in this)
                    yield return item;
            }
            set
            {
                if (value != null)
                    foreach (var item in value)
                        Add(item);
            }
        }
        public Group(K Header, IEnumerable<T> Items) // Since there is no default constructor, argument names should match JSON property names.
            : base(Items)
        {
            Key = Header;
        }
    }
