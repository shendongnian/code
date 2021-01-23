    public class MyViewModel : INotifyPropertyChanged
    {
        public MyViewModel()
        {
            CarModels = new[] {"Mazda", "VW", "Audi"};
            SelectedCarModel = "VW";
        }
    
        public IEnumerable<string> CarModels { get; private set; }
    
        private string _selectedCarModel;
        public string SelectCarModel
        {
            get { return _selectedCarModel; }
            set
            {
                if (_selectedCarModel == value) return;
    
                _selectedCarModel = value;
                OnPropertyChanged("SelectedCarModel");
            }
        }
    }
