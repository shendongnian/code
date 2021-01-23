    public class MyViewModel
    {
        public ObservableCollection<Document> Documents { get; set; }    
    
        public CollectionView MostRecentDocuments
        {
            get 
            {
                var view = new CollectionView(Documents);
                view.Filter = x => Documents.Take(5).Contains(x);
                return view;
            }
        }
    }
