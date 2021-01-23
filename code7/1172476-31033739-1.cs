    public class AppController : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
    
            private bool m_bInit;
            private PropertyChangedEventArgs m_bInitEA = new PropertyChangedEventArgs("IsInitialized");
            public bool IsInitialized
            {
                get { return m_bInit; }
                set
                {
                    m_bInit = value;
                    if (PropertyChanged != null)
                        PropertyChanged(this, m_bInitEA);
                }
            }
        }
