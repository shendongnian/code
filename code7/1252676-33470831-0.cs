    private void txtSearchFilter_TextChanged(object sender, TextChangedEventArgs e)
            {
                ICollectionView items = CollectionViewSource.GetDefaultView(lbSkills.ItemsSource);
                if (items != null)
                {
                    items.Filter = SearchFilter;
                }
            }
    public bool SearchFilter(object filterObject)
            {
               var filter = filterObject as <<List Box item type>>;
                if (filter == null)
                {
                    return false;
                }
    
                 <<Your search logic here.......>>        
    }
