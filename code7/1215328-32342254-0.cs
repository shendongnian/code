    public class MyViewModel : INotifyPropertyChanged
    {
        public MyViewModel()
        {
        }
        private bool busy = false;
        public bool IsBusy
        {
            get { return busy; }
            set
            {
                if (busy == value)
                    return;
                busy = value;
                OnPropertyChanged("IsBusy");
            }
        }
        public async Task GetMonkeysAsync()
        {
            if (IsBusy)
                return;
            
            
            try
            {
                IsBusy = true;
                //do stuff here that is going to take a while
            }
            finally
            {
                IsBusy = false;
            }
        }
        #region INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string name)
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;
            changed(this, new PropertyChangedEventArgs(name));
        }
        #endregion
    }
