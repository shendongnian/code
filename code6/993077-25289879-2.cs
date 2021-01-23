    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
    
        private void Form1_Load(object sender, EventArgs e)
        {
            File.AppendAllText("D:\\Hello.txt", DateTime.Now.ToString());
        }
    
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            File.AppendAllText("D:\\Hello.txt", DateTime.Now.ToString());
        }
    }
