    public class MyObservableCollection<T>
        : ObservableCollection<T>
    {
        public string GetCollectionString()
        {
            return string.Join("\n", this);
        }
    }
