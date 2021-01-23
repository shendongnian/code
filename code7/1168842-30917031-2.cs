    public class MainViewModel : ViewModelBase, IBarcodeHandler
    {
        public ICollectionView TraceItemCollectionView
        {
            get { return CollectionViewSource.GetDefaultView(TraceItemCollectionViewSource); }
        }
        public ObservableCollection<TraceDataItem> TraceItemCollectionViewSource { get; set; }
    }
