    public class Mobile : ObservableCollection<MobileModelInfo>
    {
        public Mobile()
        {
            Add(new MobileModelInfo { Name = "foo", Category = "boo", Year = 1988 } );
        }
    
        public Mobile GetList()
        {
            return this;
        }
    }
