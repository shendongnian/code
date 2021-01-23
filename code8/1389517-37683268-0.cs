    public class YourClassName: INotifyPropertyChanged
    {
     public event PropertyChangedEventHandler PropertyChanged;
    
        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
    public ObservableCollection<YourModel> Offsets
        {
            get {return this.offsets;}
    
            set
            {
                if (value != this.offsets)
                {
                    this.offsets= value;
                    NotifyPropertyChanged("Offsets");
                }
            }
        }
    }
