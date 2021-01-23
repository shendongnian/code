    public class StateLogin : INotifyPropertyChanged
        {
            private int _loginState; // helping variable to trigger login state change
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            public int LoginState
            {
                get { return _loginState; }
                set
                {
                    _loginState = value;
                    OnPropertyChanged("LoginState");
                }
            }
    
            protected void OnPropertyChanged(string name)
            {
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
            }
        }
