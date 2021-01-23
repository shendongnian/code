    public abstract class NotifyPropertyChangedBase: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        
        protected virtual void OnPropertyChanged<T>(Expression<Func<T>> expression)
        {
            var memberExpression = (MemberExpression) expression.Body;
            var propertyName = memberExpression.Member.Name;
    
            var handler = PropertyChanged;
            if (handler != null) 
            {
                // Do your common actions here, before property change notification is fired
                handler(this, new PropertyChangedEventArgs(propertyName));
                // Do your common actions here, after property change notification is fired
            }
        }
    }
    
    public class MyClass : NotifyPropertyChangedBase
    {
        public Boolean ActionAlarmLowLow
        {
           get
           {
               return _ActionAlarmLowLow;
           }
           set
           {
               if (value != this._ActionAlarmLowLow)
               {
                   _ActionAlarmLowLow = value;
                   OnPropertyChanged(() => this.ActionAlarmLowLow);
               }
           }
       }
    }
