    public abstract class BaseViewModel : INotifyPropertyChanged
    {
      public event PropertyChangedEventHandler PropertyChanged;
      private Hashtable values = new Hashtable();
      protected void SetValue(string name, object value)
      {
         this.values[name] = value;
         OnPropertyChanged(name);
      }
      protected object GetValue(string name)
      {
         return this.values[name];
      }
      protected void OnPropertyChanged(string name)
      {
         PropertyChangedEventHandler handler = PropertyChanged;
         if (handler != null)
         {
            handler(this, new PropertyChangedEventArgs(name));
         }
      }
    }
