    public PropertyChangedEventHandler PropertyChanged;
    private void NotifyPropertyChanged(string propertyName)
    {
         PropertyChangedEventHandler handler = this.PropertyChanged;
         if (handler != null)
         {
              var e = new PropertyChangedEventArgs(propertyName);
              handler(this, e);
         }
    }
    private String file;
    
    public String File
    {
        get 
        { 
             return file; 
        }
        set
        {
             file = value;
             NotifyPropertyChanged("File");
        }
    }
