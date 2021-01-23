    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            your_control control = new your_control ();
            control.bu.Click += on_bu_click;
        }
        public void on_bu_click(object sender, EventArgs e)
        {
            // your stuff
        }
    }
