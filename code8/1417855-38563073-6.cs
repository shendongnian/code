    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            your_control control = new your_control();
            control.delete += on_delete;
        }
        public void on_delete(your_control sender)
        {
            // your stuff
        }
    }
