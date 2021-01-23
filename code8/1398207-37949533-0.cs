    public class ExampleVM : INotifyPropertyChanged
    {
        private string _Name;
    
        public string Name
        {
            get { return _Name; }
            set { _Name = value; OnPropertyChanged(); }
        }
    
        public string FullName { get; set; }
    
        public ExampleVM()
        {
            this.PropertyChanged += (s, a) =>
            {
                if (a.PropertyName == "Name")
                {
                    FullName = $"Mr. {Name}";
                    OnPropertyChanged("FullName");
                }
            };
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
    
        void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
