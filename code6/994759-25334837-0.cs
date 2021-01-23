    using System.Windows;
    namespace WpfApplication1
     {
        /// <summary>    
        /// Interaction logic for MainWindow.xaml    
        /// </summary>
    
        public partial class MainWindow : Window
        {
            private string _test = "testing 1..2..3";    
            public string Test { get { return _test; } set { _test = value; } }
    
            public MainWindow()
            {
                InitializeComponent();
                this.Loaded+=(s,a)=>
                 {
                    this.DataContext=Test;
                 };
            }
        }
    }
