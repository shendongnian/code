    private PagedCollectionView _dataGridContext;
    private void WebService_ReadPismaCompleted(object sender,serviceReference1.ReadPismaCompletedEventArgs e)
        {
            if(e.Result != null)
            {
                DataGridContext = new PagedCollectionView(e.Result)
            }
        }
     
      public PagedCollectionView DataGridContext
      {
         get { return _dataGridContext; }
         set { 
               _dataGridContext = value; 
               OnPropertyChanged("DataGridContext");
             }
      }
