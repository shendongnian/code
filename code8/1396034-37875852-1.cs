     private List<ListItems> list;
    
            public List<ListItems> List
            {
                get { return list; }
                set
                {
                    list = value;
                    this.NotifyPropertyChanged("List");
                }
            }
    
            public IEnumerable<MyType> DataTypeValues
            {
                get
                {
                    return Enum.GetValues(typeof(MyType)).Cast<MyType>().ToList<MyType>();
                }
            }
    
            public ViewModel()
            {
                List = new List<ListItems>();
                List.Add(new ListItems());
                List.Add(new ListItems());
    
            }
