    public class Hero : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string _name = string.Empty;
        public string Name
        {
           get { return _name; }
           set
           {
              _name = value;
              if (PropertyChanged != null)
              {
                 PropertyChanged(this, new PropertyChangedEventArgs("Name"));
              }
           }
        }
    }
