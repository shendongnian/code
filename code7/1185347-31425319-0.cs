    public class CitySelector : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    
    
        private ObservableCollection<City> cities;
        public ObservableCollection<City> Cities
        {
            get { return cities; }
            set
            {
                if (cities != value)
                {
                    cities = value;
                    NotifyPropertyChanged("Cities");
                }
            }
        }
    
        private ObservableCollection<Department> departments;
        public ObservableCollection<Department> Departments
        {
            get { return departments; }
            set
            {
                if (departments != value)
                {
                    departments = value;
                    NotifyPropertyChanged("Departments");
                }
            }
        }
    
        private List<Department> MyDepartments;
    
        private City selectedCity;
        public City SelectedCity
        {
            get { return selectedCity; }
            set
            {
                if (selectedCity != value)
                {
                    selectedCity = value;
                    if (selectedCity == null)
                        Departments = null;
                    else
                        Departments = MyDepartments.Where(x => x.CityId == selectedCity.Id).ToList();
                    NotifyPropertyChanged("SelectedCity");
                }
            }
        }
    
        public CitySelector()
        {
            MyDepartments = new List<Department>() { new Department() { name = "Dep1", CityId = 1}, new Department() {name = "Dep2", CityId = 2}, new Department() {name = "Dep3", CityId = 3 } };
            Cities = new ObservableCollection<City>() { new City() { Id = 1, name = "City 1" }, new City() { Id = 2, name = "City 2" }, new City() { Id = 3, name = "City 3" } };
    
            this.DataContext = this;
        }
    }
