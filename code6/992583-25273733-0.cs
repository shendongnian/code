    using System.ComponentModel;
    namespace WpfMagic
    {
        public class MainViewModel : INotifyPropertyChanged
        {
            private static readonly MainViewModel instance = new MainViewModel();
            public static MainViewModel Instance { get { return instance; } }
            private bool isConnected;
            public bool IsConnected
            {
                get { return isConnected; }
                set
                {
                    if (value != isConnected)
                    {
                        isConnected = value;
                        PropertyChanged(this, new PropertyChangedEventArgs("IsConnected"));
                    }
                }
            }
            private MainViewModel()
            {
            }
            public event PropertyChangedEventHandler PropertyChanged = delegate { };
        }
    }
