    private ObservableCollection<SimpleClass> _simpleCollection;
            public ObservableCollection<SimpleClass> SimpleCollection
            {
                get { return _simpleCollection ?? (_simpleCollection = new ObservableCollection<SimpleClass>()
                {
                    new SimpleClass
                    {
                        A = "1", B = "2"
                    },
                    new SimpleClass
                    {
                        C = "3", D = "4"
                    },
                    new SimpleClass
                    {
                        E = "5", F = "6"
                    }
                }); }
                set
                {
                    _simpleCollection = value;
                }
            }
        public class SimpleClass
        {
            public string A { get; set; }
            public string B { get; set; }
            public string C { get; set; }
            public string D { get; set; }
            public string E { get; set; }
            public string F { get; set; }
        }
