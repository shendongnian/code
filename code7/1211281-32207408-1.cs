    namespace WpfApplication1
    {
        public class MainViewModel : ViewModelBase
        {
            public ObservableCollection<DataLogContent> DataLogList { get; private set; }
    
            public MainViewModel()
            {
                DataLogList = new ObservableCollection<DataLogContent>();
                DataLogList.Add(new DataLogContent
                {
                    DataLogLabel = "Label",
                    DataLogName = "Name"
                });
    
                DataLogList.Add(new DataLogContent
                {
                    DataLogLabel = "Label2",
                    DataLogName = "Name2"
                });
            }
        }
    
        public class DataLogContent : ViewModelBase
        {
            private string dataLogLabel;
            public string DataLogLabel
            { 
                get { return this.dataLogLabel; }
                set
                {
                    this.dataLogLabel = value;
                    OnPropertyChanged("DataLogLabel");
                }
            }
    
            private string dataLogName;
            public string DataLogName
            {
                get { return this.dataLogName; }
                set
                {
                    this.dataLogName = value;
                    OnPropertyChanged("DataLogName");
                }
            }       
        }
    }
