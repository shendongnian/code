    public Windows.UI.Xaml.Data.ICollectionView GroupedData { 
        get
        {
            return cvSource.View;
        }  
    }
    public YourObjectType CurrentItem {
        get {
            return this.currentItem;
        }
        set {
            if (this.currentItem != value) {
                this.currentItem  = value;
                this.OnPropertyChanged("CurrentItem");
            }
        }
    }
    private YourObjectType currentItem;
    private Windows.UI.Xaml.Data.CollectionViewSource cvSource;
