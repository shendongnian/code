    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public MainWindowViewModel()
        {
            ViewModelCollection = new ObservableCollection<DummyViewModel>();
            ViewModelCollection.Add(new DummyViewModel("Tab1", "Content for Tab1"));
            ViewModelCollection.Add(new DummyViewModel("Tab2", "Content for Tab2"));
            ViewModelCollection.Add(new DummyViewModel("Tab3", "Content for Tab3"));
            ViewModelCollection.Add(new DummyViewModel("Tab4", "Content for Tab4"));
        }
    
        public ObservableCollection<DummyViewModel> ViewModelCollection { get; set; }
    
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    public class DummyViewModel
    {
        public DummyViewModel(string name, string description)
        {
            Name = name;
            Description = description;
        }
        public string Name { get; set; }
        public string Description { get; set; }
    }
