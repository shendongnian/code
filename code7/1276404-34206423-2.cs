        public class DataStore
        {
            public ObservableCollection<Country> Countries { get; set; }
    
            public DataStore()
            {
                Countries = new ObservableCollection<Country>();
                Countries.Add(new Country() { Area = 12345, Capital = "NewDelhi", Formed = DateTime.Parse("1/1/1990"), Name = "India",
                    States = new ObservableCollection<State>() { new State() { Area = 112345, Capital = "Bhopal", Name = "MP" }, new State() { Area = 113456, Capital = "Lucknow", Name = "UP" } }
                });
                Countries.Add(new Country() { Area = 22345, Capital = "Washington DC", Formed = DateTime.Parse("1/1/1995"), Name = "USA",
                    States = new ObservableCollection<State>() { new State() { Area = 212345, Capital = "Silicon Valley", Name = "Pennysylvania" }, new State() { Area = 213456, Capital = "NewYork", Name = "Old Trafford" } }
                });
            }
        }
    
        public class Country
        {
            public string Name { get; set; }
            public int Area { get; set; }
            public string Capital { get; set; }
            public DateTime Formed { get; set; }
            public ObservableCollection<State> States { get; set; }
        }
    
        public class State
        {
            public string Name { get; set; }
            public int Area { get; set; }
            public string Capital { get; set; }
        }
