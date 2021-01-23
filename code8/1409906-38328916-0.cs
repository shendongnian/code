    public class FormatContainerViewModel : ViewModelBase, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        //Add notifyPropertyChanged on your desired property
        //Example
        
        private ObservableCollection<ViewModel> _subFormats;
        public ObservableCollection<ViewModel> SubFormats
        {
            get
            {
                return _subFormats;
            }
            set
            {
                Set(() => SubFormats, ref _subFormats, value);
                RaisePropertyChanged("SubFormats");
                NotifyPropertyChanged("SubFormats");
            }
        }
      
        
    }
