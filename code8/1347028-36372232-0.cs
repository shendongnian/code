    namespace KeyDown
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                myGrid.Focus(); // focus programmatically, better put it in OnLoaded event
            }
    
            private void MainGrid_KeyDown(object sender, KeyEventArgs e)
            {
                MessageBox.Show("Key pressed");
            }
        }
    }
