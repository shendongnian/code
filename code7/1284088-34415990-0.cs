    BookList.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler( BookList_CollectionChanged );
    void BookList_CollectionChanged( object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e )
    {
        if ( e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove )
		{
		}
    }
