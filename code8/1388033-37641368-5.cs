    public class MyObservableCollection<T> : ObservableCollection<T>
    {
        public event NotifyCollectionChangedEventHandler AfterCollectionChanged;
        protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            base.OnCollectionChanged(e);
            AfterCollectionChanged?.Invoke(this, e);
        }
    }
