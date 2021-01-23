    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
        }
    
        void Form1_Load(object sender, EventArgs e)
        {
            webBrowserControl.Navigate("file:///C:/Temp/select.html");
        }
    
        private void toggle_Click(object sender, EventArgs e)
        {
            webBrowserControl.Document.GetElementById("togglingOption").SetAttribute("selected", "");
        }
    }
