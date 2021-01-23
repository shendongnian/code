    public partial class Form1 : Form
    {
        static public string gettext { get; set; }
        
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Class1.send();
            textBox1.Text = gettext;
        }
    }
    
