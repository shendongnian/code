      public static BindingListCollectionView GetCollectionView(this DataTable table)
            {
                return new BindingListCollectionView(table.DefaultView);
            }
    		
    
    
     public static DataTable GetDataTable(this BindingListCollectionView view)
        {
            var dataView = view.SourceCollection as DataView;
            if (dataView != null)
            {
                return dataView.Table;
            }
    
            return null;
        }
