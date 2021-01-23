    public ICollectionView Team
    {
        get
        {
            CollectionViewSource cvs = new CollectionViewSource { Source = People, IsLiveFilteringRequested = true, LiveFilteringProperties = { "Num" } };
            cvs.View.Filter = p => ((Person)p).Num != 11;
            cvs.View.CollectionChanged += EmptyEventHandler;
            return cvs.View;
        }
    }
    private void EmptyEventHandler(object sender, NotifyCollectionChangedEventArgs e) { }
