    public class RootObject
    {
        [JsonConverter(typeof(KeyedListPropertySynchronizingConverter))]
        public ObservableCollection<Item> Items { get; set; } // Can be any type of collection implementing IList<T>
    }
