    namespace ResizeSample
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }
    
            private void Button_Remove_Click(object sender, RoutedEventArgs e)
            {
                // we gave the hosting grid a name, so now we can remove the sender of the click event from the grid.
                // remember to cast the sender to UIElement!
                Grid_ButtonHost.Children.Remove((UIElement)sender);
            }
        }
    }
