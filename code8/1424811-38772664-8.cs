    namespace WpfWindow
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            TitleBarWindow w = new TitleBarWindow();
    
            public MainWindow()
            {
                InitializeComponent();
    
                w.ShowActivated = true;
                w.Background = Brushes.Red;
            }
    
            private void Window1_LocationChanged(object sender, EventArgs e)
            {
                Point pt = Window1.PointToScreen(new Point(0, 0));
                w.Top = pt.Y - 27;
                w.Left = pt.X;
            }      
    
            private void Window1_Activated(object sender, EventArgs e)
            {
                Point pt = Window1.PointToScreen(new Point(0, 0));
                w.Top = pt.Y-27;
                w.Left = pt.X;
                
                w.Show();
            }
    
            private void Window1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
            {
                w.Close();
            }
        }
    }
