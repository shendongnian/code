    public class KeyedList<T> : ObservableCollection<T>
    {
        public object Key
        { get; set; }
        public KeyedList()
        { }
        public KeyedList(IGrouping<object, T> group)
        {
            Key = group.Key;
            foreach (var member in group)
                Add(member);
        }
    }
