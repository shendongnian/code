      public class ViewModelBase : INotifyPropertyChanged
      {
         public event PropertyChangedEventHandler PropertyChanged;
         protected void FirePropertyChanged([CallerMemberName] string propertyName = null)
         {
            if (propertyName == null)
               throw new ArgumentNullException("propertyName");
            try
            {
               this.OnPropertyChanged(propertyName);
            }
            catch (Exception exception)
            {
               Trace.TraceError("{0}.OnPropertyChanged threw {1}: {2}", this.GetType().FullName, exception.GetType().FullName, exception);
            }
         }
         protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
         {
            var handler = PropertyChanged;
            if (handler != null)
            {
               handler(this, new PropertyChangedEventArgs(propertyName));
            }
         }
      }
     public class Ethernet : ViewModelBase
      {
         private DataTime timeStamp;
         public DateTime TimeStamp
         {
            get
            {
               return timeStamp;
            }
            set
            {
               timeStamp = value;
               FirePropertyChanged();
            }
         }
      }
