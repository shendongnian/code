    public class ValuesViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
    
        public ObservableCollection<string> WindowTitles { get; private set; }
    
        public ValuesViewModel()
        {
            WindowTitles = new ObservableCollection<string>();
        }
    
        public void AddTitleIfUnique(string title)
        {
            if (!WindowTitles.Contains(title))
                WindowTitles.Add(title);
        }
    }
