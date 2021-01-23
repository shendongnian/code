    namespace WpfApplication1
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
    
                Type newType = Type.GetType("WpfApplication1.uc1", true, true);
    
                object o = Activator.CreateInstance(newType);
                StkPanel.Children.Add(UIElement o);
            }
        }
    }
