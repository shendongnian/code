    [Serializable]
    [ProtoContract]
    public class ObservableList2<T> : ObservableCollection<T>
    { 
        public void Add(IEnumerable<T> list)
        {
            foreach (var item in list)
                Add(item);
        }
    }
