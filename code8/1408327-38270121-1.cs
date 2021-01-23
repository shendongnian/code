    public partial class MainWindow : Window
    {
        State state;
        public MainWindow()
        {
            InitializeComponent();
            state = new State();
            state.StatusChanged += new RoutedEventHandler(state_StatusChanged);
            state.Status = true;
       
        }
        void state_StatusChanged(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(this.state.StatusText); 
        }
    }
