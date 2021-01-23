    public abstract class ExtendedObservableCollection<T> : ObservableCollection<T> where T : INotifyPropertyChanged
    {
        protected override void ClearItems()
        {
            foreach (var item in Items) item.PropertyChanged -= ItemPropertyChanged;
            base.ClearItems();
        }
        protected override void InsertItem(int index, T item)
        {
            item.PropertyChanged += ItemPropertyChanged;
            base.InsertItem(index, item);
        }
        protected override void RemoveItem(int index)
        {
            this[index].PropertyChanged -= ItemPropertyChanged;
            base.RemoveItem(index);
        }
        protected override void SetItem(int index, T item)
        {
            this[index].PropertyChanged -= ItemPropertyChanged;
            item.PropertyChanged += ItemPropertyChanged;
            base.SetItem(index, item);
        }
        abstract void ItemPropertyChanged(object sender, PropertyChangedEventArgs e);
    }
