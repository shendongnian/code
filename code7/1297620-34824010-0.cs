    class WrappedObservableCollection<TElement> : INotifyPropertyChanged, INotifyCollectionChanged //, ...others
    {
        private readonly ObservableCollection<TElement> BaseList;
        public WrappedObservableCollection(ObservableCollection<TElement> baseList)
        {
            Contract.Requires(baseList != null);
            this.BaseList = baseList;
            ((INotifyPropertyChanged)this.BaseList).PropertyChanged += (sender, e) => PropertyChanged?.Invoke(this, e);
        }
        #region wrapping of BaseList
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
    }
