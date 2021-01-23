        public class MVVMList: INotifyPropertyChanged
            {
        //Singleton section
                private static MVVMList instance;
                private MVVMList() { }
                public static MVVMList Instance
                {
                    get
                    {
                        if (instance == null)
                        {
                            instance = new MVVMList();
                        }
                        return instance;
                    }
                }
     //end singleton section           
                private ObservableCollection<string> _onglets = new ObservableCollection<string>();
                public ObservableCollection<string> Onglets
                {
                    get { return _onglets; }
                    set
                    {
                        if (_onglets != value)
                        {
                            _onglets = value;
                            if (PropertyChanged != null)
                                PropertyChanged.Invoke(this,
                                    new PropertyChangedEventArgs("onglets_list"));
                        }
                    }
                }
        
        //INotify implementation 
                public event PropertyChangedEventHandler PropertyChanged;
            }
