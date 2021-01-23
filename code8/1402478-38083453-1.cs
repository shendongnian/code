    public class MyViewModel : INotifyPropertyChanged
    {
            public States CurrentState
            {
                get { return _CurrentState; }
                set
                {
                    _CurrentState = value;
                    PropertyChanged("CurrentState");
                }
         }
