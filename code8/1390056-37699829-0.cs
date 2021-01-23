    public class MainUIModel : INotifyPropertyChanged
    {
        public ObservableCollection<RandomList> randomList{ get; set; }
    
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
