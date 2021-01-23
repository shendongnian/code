    public class KeyValueCollection : ObservableCollection<KeyValue>
    {
        public Value this[string key]
        {
            get
            {
                var item = this.FirstOrDefault(x => x.Key == key);
                return item != null ? item.Value : null;
            } 
        }
    }
