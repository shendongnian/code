    // this is a filter item
    public class CountryFilterItem : INotifyPropertyChanged
    {
        public string CountryName { ... }
        public bool IsChecked { ... }
    }
    
    public class ViewModel
    {
        // this property is a replacement for "Country";
        // bind it to some ItemsControl is the filter view
        public IEnumerable<CountryFilterItem> Countries
        {
            get { return _countries; }
        }
    
        // fill filter somewhere;
        // when filling, subscribe on `PropertyChanged` event of each item;
        // when user will change IsChecked for item, you'll update filter:
        // 
        // var country = new Country { CountryName = "Zimbabwe" };
        // country.PropertyChanged += (sender, args) =>
        // {
        //     if (propertyName == "IsChecked")
        //     {
        //         PersonListView.Refresh();
        //     }
        // };
        // _countries.Add(country);
        private List<CountryFilterItem> _countries;
    
        // filtering logic
        private bool ShouldViewPerson(Person p)
        {
            // implement filtering logic here;
            // e.g.:
            return _countries.Any(_ => _.IsChecked && _.CountryName == p.Country) && p.Sex == Sex;
        }
    
        // other code here...
    }
