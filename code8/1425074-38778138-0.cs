    public class Caller : BaseClass{
    
        protected override void OnPropertyChanged(PropertyChangedEventArgs eventArgs){
            // handle stuff
        }
    }
    
    public abstract class BaseClass : INotifyPropertyChanged{
    
        protected abstract void OnPropertyChanged(PropertyChangedEventArgs eventArgs);
    }
