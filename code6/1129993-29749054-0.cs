    public class MainViewModel : INotifyPropertyChanged
    {
      // This event is for the INotifyPropertyChanged interace
      public event PropertyChangedEventHandler PropertyChanged;
      // This is a helper method that makes it straightforward to raise the PropertyChanged event
      public void NotifyPropertyChanged(string propertyName)
      {
    	PropertyChangedEventHandler handler = this.PropertyChanged;
    	if (handler != null)
    	{
    		handler(this, new PropertyChangedEventArgs(propertyName));
    	}
      } 
      private Rect selection;
      public Rect Selection
      {
        get
        {
          return this.selection;
        }
        set
        {
          this.selection = value;
          // Alert the View that the property has been changed
          this.NotifyPropertyChanged("Selection");
        }
      }
    }
