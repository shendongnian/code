    var dgCollectionView = dataGrid.ItemsSource as DataGridCollectionView;
    if( m_dgCollectionView != null )
    {
        foreach( var itemProperty in m_dgCollectionView.ItemProperties )
        {
            PropertyChangedEventManager.AddListener( itemProperty, this, "FilterCriterion" );
        }
    }
    public bool ReceiveWeakEvent( Type managerType, object sender, EventArgs e )
    {
        if( managerType == typeof( PropertyChangedEventManager ) )
        {
            var itemProperty = sender as DataGridItemProperty;
            // your code here
        }
        return true;
    }
