    public class WindowAlpha : Window
    {
        public WindowAlpha()
        {
            Activated += MyOnActivated;
        }
    
        protected virtual void MyOnActivated(object sender, EventArgs args)
        {
            MessageBox.Show("Started")
        }
    }
    
    public class WindowBravo : WindowAlpha
    {
    }
    
    public partial class MainWindow : WindowBravo
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    
        protected override void MyOnActivated(object sender, EventArgs args)
        {
        }
    }
