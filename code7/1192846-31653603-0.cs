    using System.Windows;
    
    namespace WpfApplication1
    {
        public partial class MainWindow
        {
            public MainWindow()
            {
                InitializeComponent();
                Loaded += MainWindow_Loaded;
            }
    
            private void MainWindow_Loaded(object sender, RoutedEventArgs e)
            {
                var dataContext = new[]
                {
                    new MyData
                    {
                        Text = "a happy smiley",
                        Value = ":)"
                    },
                    new MyData
                    {
                        Text = "a sad smiley",
                        Value = ":("
                    }
                };
                DataContext = dataContext;
            }
        }
    
        internal class MyData
        {
            public string Text { get; set; }
            public object Value { get; set; }
        }
    }
