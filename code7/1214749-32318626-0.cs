    public class YourViewModelClass:INotifyPropertyChanged
    { 
      public event PropertyChangedEventHandler PropertyChanged;
    
      public MyItems MyItemsInstance
      {
        get
        {
            return this.customerNameValue;
        }
        set
        {
            if (value != this.customerNameValue)
            {
                this.customerNameValue = value;
                NotifyPropertyChanged();
            }
        }
      }
    
      private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
      {
          if (PropertyChanged != null)
          {
              PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
          }
      }
    }
