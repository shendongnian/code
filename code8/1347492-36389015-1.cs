    public partial class MainWindow : Window
    {
        private readonly Storyboard storyboard2;
        public MainWindow()
        {
            InitializeComponent();
            storyboard2 = (Storyboard)FindResource("storyboard2");
        }
        private void button1_Completed(object sender, EventArgs e)
        {
            frame1.Content = "Button #1 Content";
            storyboard2.Begin(frame1);
        }
        private void button2_Completed(object sender, EventArgs e)
        {
            frame1.Content = "Button #2 Content";
            storyboard2.Begin(frame1);
        }
        private void button3_Completed(object sender, EventArgs e)
        {
            frame1.Content = "Button #3 Content";
            storyboard2.Begin(frame1);
        }
    }
