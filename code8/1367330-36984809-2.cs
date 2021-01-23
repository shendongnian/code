    public event PropertyChangedEventHandler PropertyChanged;
    private void NotifyPropertyChanged(String info)
    {
        if (PropertyChanged != null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(info));
        }
    }
    public class Car
    {
        private string _make ;
        public string Make
        {
          get { return _make ; }
          set
          {
             _make = value;
             //This will update each time you set a value to the userinterface
             NotifyPropertyChanged("Make");
          }
      }
    }
