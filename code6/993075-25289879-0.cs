    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
    
        private void Form1_Load(object sender, EventArgs e)
        {
            File.WriteAllText("D:\\Hello.txt", DateTime.Now.ToString());
        }
    
        private void Form_Closed(object sender, EventArgs e)
        {
            File.WriteAllText("D:\\Hello.txt", DateTime.Now.ToString());
        }
    }
