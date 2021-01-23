    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            MessageBox.Show(this, string.Format("Lanched Via Startup Arg:{0}", Program.LaunchedViaStartup));
        }
    }
