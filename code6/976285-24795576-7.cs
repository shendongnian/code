    namespace WpfApplication1
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        
        
        public partial class GUIA : Window
        {
            static bool IsAppStart = true;
    
            public GUIA()
            {
                InitializeComponent();
                this.Loaded += GUIA_Loaded;
            }
    
            public GUIA(bool isAppStart)
            {
                IsAppStart = isAppStart;
                this.Loaded += GUIA_Loaded;
            }
    
            void GUIA_Loaded(object sender, RoutedEventArgs e)
            {
                if (IsAppStart)
                {
                    this.WindowState = System.Windows.WindowState.Minimized;
                }
            }
    
            private void btnCloseAnotherWindow_Click(object sender, RoutedEventArgs e)
            {
                GUIA obj = new GUIA(false);
                obj.Show();
            }
    
        }
    }
