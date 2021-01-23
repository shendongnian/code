    public class CompareConverter: IValueConverter, INotifyPropertyChanged{
      private ComparisonType _comparison = ComparisonType.Equals;
      public ComparisonType Comparison {
        get {return _comparison; }
        set { _comparison = value; OnPropertyChanged(); }
      }
     
      private string _compareTo = null;
      public string CompareTo {
        get {return _compareTo; }
        set { _compareTo = value; OnPropertyChanged(); }
      }
    
      public event PropertyChangedEventHandler PropertyChanged;
    
      protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
      { 
    	if (PropertyChanged != null) 
    		PropertyChanged(this, new PropertyChangedEventArgs(propertyName)); 
      } 
    
      public object Convert (object value, Type targetType, object parameter, 
         System.Globalization.CultureInfo culture)
      {
        bool result = false;
        switch (Comparison)...
        return result;
      } 
      ...
    }
