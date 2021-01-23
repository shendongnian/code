    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.ClientSize = Screen.PrimaryScreen.Bounds.Size;
            this.Left = 0;
            this.Top = 0;
            this.Opacity = 0.5;
        }
    }
