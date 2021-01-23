    public class MyViewModel
    {
        CollectionView _mostRecentDocuments;
        public MyViewModel()
        {
            Documents = new ObservableCollection<Document>();
            _mostRecentDocuments = new CollectionView(Documents);
            _mostRecentDocuments .Filter = x => Documents.Take(5).Contains(x);
        }
    
        public ObservableCollection<Document> Documents { get; private set; }    
    
        public CollectionView MostRecentDocuments
        {
            get 
            {
                return _mostRecentDocuments;
            }
        }
    }
