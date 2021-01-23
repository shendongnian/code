    namespace WpfApplication1
    {
        
        public partial class MainWindow : Window, INotifyPropertyChanged
        {
            #region Inotify
            /// <summary>
            /// Property Change Event
            /// </summary>
            public event PropertyChangedEventHandler PropertyChanged;
    
            /// <summary>
            /// Property Change Method
            /// </summary>
            /// <param name="prop">Property Name</param>
            internal void RaisePropertyChanged(string prop)
            {
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs(prop));
                }
            }
    
            #endregion
    
            #region Constructor
    
            public MainWindow()
            {
                this.DataContext = this;
                InitializeComponent();
            }
            #endregion
    
            #region Properties
    
            private ObservableCollection<Lender> lenderList;
    
            public ObservableCollection<Lender> LenderList
            {
                get { return lenderList; }
                set
                {
                    lenderList = value;
                    RaisePropertyChanged("LenderList");
                }
            }
            #endregion
    
            #region Events
    
    
            private void Window_Loaded(object sender, RoutedEventArgs e)
            {
                LenderList = new ObservableCollection<Lender>();
                Lender l = new Lender();
                l.CompanyName = "11212dffdd";
                l.ID = "1";
                LenderList.Add(l);
                cboLender.ItemsSource = LenderList;
                cboLender.DisplayMemberPath = "CompanyName";
    
    
                var selectedLender = LenderList.SingleOrDefault(x => x.ID == "1");
                cboLender.SelectedItem = selectedLender;
                cboLender.SelectedValuePath = "CompanyName";
                cboLender.SelectedValue = selectedLender.CompanyName;
    
            }
            #endregion
        }
    
        public class Lender : INotifyPropertyChanged
        {
            #region Inotify
            /// <summary>
            /// Property Change Event
            /// </summary>
            public event PropertyChangedEventHandler PropertyChanged;
    
            /// <summary>
            /// Property Change Method
            /// </summary>
            /// <param name="prop">Property Name</param>
            internal void RaisePropertyChanged(string prop)
            {
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs(prop));
                }
            }
    
            #endregion
    
            private string companyName;
    
            public string CompanyName
            {
                get { return companyName; }
                set
                {
                    companyName = value;
                    RaisePropertyChanged("CompanyName");
                }
            }
    
            private string id;
    
            public string ID
            {
                get { return id; }
                set
                {
                    id = value;
                    this.RaisePropertyChanged("ID");
                }
            }
        }
    }
