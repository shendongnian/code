    using System.ComponentModel;
    
    public partial class ucFilterDataGrid : UserControl, INotifyPropertyChanged
    {
        public static readonly DependencyProperty WatermarkContentProperty = DependencyProperty.Register("WatermarkContent", typeof(string), typeof(ucFilterDataGrid), new FrameworkPropertyMetadata(string.Empty));
        public event PropertyChangedEventHandler PropertyChanged;
        
        public ucFilterDataGrid()
        {
            InitializeComponent();
        }
        
        public string WatermarkContent
        {
            get { GetValue(WatermarkContentProperty).ToString(); }
            set { 
                 SetValue(WatermarkContentProperty, value); 
                 RaisePropertyChanged();
            }
        }
           
        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
