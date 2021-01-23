    public class SharedViewModel : INotifyPropertyChanged
    {
        private ICommand clickCommand;
        private int currentValue;
        /* INotifyPropertyChanged implementation */
    
        public SharedViewModel()
        {
            ClickCommand = new Command(() => CurrentValue = CurrentValue + 1);
        }
        public ICommand ClickCommand 
        {
            get { return clickCommand; }
            set
            {
               clickCommand = value;
               OnPropertyChanged("ClickCommand");
            }
        }
        public int CurrentValue 
        {
            get { return currentValue; }
            set
            {
               currentValue = value;
               OnPropertyChanged("CurrentValue");
            }
        }
    }
