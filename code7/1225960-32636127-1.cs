    namespace WpfDataGrid._32635114
    {
        /// <summary>
        /// Interaction logic for Win32635114.xaml
        /// </summary>
        public partial class Win32635114 : Window
        {
            public Win32635114()
            {
                InitializeComponent();
    
                DataStore store = new DataStore();
                this.DataContext = store;
            }
        }
    }
