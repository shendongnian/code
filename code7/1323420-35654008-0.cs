    public class ModelItem : INotifyPropertyChanged
    {
            
      private int modelNumber;
      public int ModelNumber
      {
        get { return modelNumber; }
        set 
        {
              
          modelNumber = value; 
          NotifyPropertyChanged("ModelNumber"); }
        }
    
      //Similar implementation for other Properties Model Name, Manufacturer
            
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
          PropertyChangedEventHandler handler = PropertyChanged;
          if (null != handler)
          {
            handler(this, new PropertyChangedEventArgs(propertyName));
          }
        }
    }
