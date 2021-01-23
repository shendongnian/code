    public class MyObject : INotifyPropertyChanged, IDataErrorInfo
    {
     public event PropertyChangedEventHandler PropertyChanged;
   
     private string _myValue;
     public string MyValue
     {
       get { return _myValue; }
       set 
       {
         _myValue = value;
         OnPropertyChanged("MyValue");
       }
     }
     private void OnPropertyChanged(PropertyChangedEventArgs e)
     {
         var handler = PropertyChanged;
         if (handler != null)
         PropertyChanged(this, e);
     }
     public string Error
        {
            get { return null; }
        }
        public string this[string columnName]
        {
            get
            {
                string returnValue = null;
                switch (columnName)
                {
                    case "MyValue":
                       if MyValue != "expected"
                          returnValue = "MyValue is not expected";
                }
                return returnValue;
             }
        }
    }
