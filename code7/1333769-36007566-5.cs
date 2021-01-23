    public class MainPageViewModel : INotifyPropertyChanged
    {
        private System.Nullable<DateTimeOffset> date;
    
        public MainPageViewModel()
        {
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
    
        public System.Nullable<DateTimeOffset> Date
        {
            get { return date; }
            set
            {
                date = value;
                OnPropertyChanged();
            }
        }
    
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
