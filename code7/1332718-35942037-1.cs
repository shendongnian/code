     public class BookcaseCatalog: IMethod<Bookcase>
    {
        private ObservableCollection<Bookcase> obsCase;
       public string ConnectionString { get; set; }
        public void Add(Bookcase obj)
        {
    
        }
    
        public void Add<T>(T obj)
        {
            //Do smth
        }
    }
