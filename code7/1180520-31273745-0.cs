    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Resize += new EventHandler(Form1_Resize);
        }
        void Form1_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Normal;
            }
        }
    }
