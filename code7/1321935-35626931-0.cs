    public class ObservableList<T> : ObservableCollection<T>
    { 
        public void Add(IEnumerable<T> list)
        {
            foreach (var item in list)
                Add(item);
        }
    }
