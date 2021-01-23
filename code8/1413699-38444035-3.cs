    public partial class MainWindow : Window
        {
            MyViewModel viewModel;
    
            public MainWindow()
            {
                InitializeComponent();
    
                viewModel = new MyViewModel();
                DataContext = viewModel;
            }
    
            private void Window_Loaded(object sender, RoutedEventArgs e)
            {
                double[] my_array = new double[10];
    
                for (int i = 0; i < my_array.Length; i++)
                {
                    my_array[i] = Math.Sin(i);
                    viewModel.Data.Collection.Add(new Point(i, my_array[i]));
                }
            }
        }
