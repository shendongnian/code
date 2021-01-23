    public partial class DataContextSample : Window
    {
        public Source Source { get; set; }
        public string HeaderText { set; get; }
    
        public MainWindow()
        {
            InitializeComponent();
    
            HeaderText = "YES";
            Source = new Source { HeaderText2 = "YES" };
            DataContext = this;
        }
    
        private void btnUpdateSource_Click(object sender, RoutedEventArgs e)
        {
            BindingExpression binding = txtWindowTitle.GetBindingExpression(TextBox.TextProperty);
            if (binding != null)
            {
                binding.UpdateSource();
            }
                
            Source.HeaderText2 = "YES2";
        }
    }
