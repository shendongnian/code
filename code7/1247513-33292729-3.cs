    using System.Windows;
    namespace TestSO33289488UserControlUnloaded
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
            private bool _removeUserControl;
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                if (_removeUserControl)
                {
                    //grid1.Children.Clear();
                    // Calling Clear() is better, but if you really want to loop,
                    // it is possible to do correctly. For example:
                    while (grid1.Children.Count > 0)
                    {
                        grid1.Children.RemoveAt(grid1.Children.Count - 1);
                    }
                    button1.Content = "Add UserControl";
                }
                else
                {
                    grid1.Children.Add(new UserControl1());
                    button1.Content = "Remove UserControl";
                }
                _removeUserControl = !_removeUserControl;
            }
        }
    }
