    /// <summary>
    /// A class that you can set as your DataContext
    /// </summary>
    public class YourViewModel : INotifyPropertyChanged
    {
       private int _radioValue;
       /// <summary>
       /// The RadioValue that your binding will find
       /// </summary>
       public int RadioValue
       {
          get { return _radioValue; }
          set
          {
             if ( value != -1 ) {
                _radioValue = value;
                /*some important action*/
                OnPropertyChanged();
             }
          }
       }
    
       /// <summary>
       /// Implementation of INotifyPropertyChanged event
       /// </summary>
       public event PropertyChangedEventHandler PropertyChanged;
    
       /// <summary>
       /// Implementation of INotifyPropertyChanged
       /// </summary>
       /// <param name="propertyName">The name of the property that has changed</param>
       protected virtual void OnPropertyChanged( [CallerMemberName] string propertyName = null )
       {
          PropertyChanged?.Invoke( this, new PropertyChangedEventArgs( propertyName ) );
       }
    }
