        public class DummyClass
        {
            public int Value { get; set; }
            public string DisplayValue { get; set;}
        }
        public ObservableCollection<DummyClass> DummyClassCollection
        {
            get
            {
                return new ObservableCollection<DummyClass>
                {
                    new DummyClass{DisplayValue = "Item1", Value = 1},
                    new DummyClass{DisplayValue = "Item2", Value = 2},
                    new DummyClass{DisplayValue = "Item3", Value = 3},
                    new DummyClass{DisplayValue = "Item4", Value = 4},
                };
            }
        }
