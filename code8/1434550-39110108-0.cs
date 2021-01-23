    public class NetworkConnectivity : MvxNotifyPropertyChanged
    {
        private bool _hasNetworkConnection;
        public bool HasNetworkConnection { 
            get { return _hasNetworkConnection; }
            set { 
                _hasNetworkConnection = value;
                RaisePropertyChanged();
            }
        }
    }
