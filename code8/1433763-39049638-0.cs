    public partial class Form1 : Form
    {
        private int i = 0;
        private int g = 0;
        public Form1()
        {
            InitializeComponent();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            g = 1;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            textBox1.AppendText("ID: [" + i++ + "] Variable value: [" + g + "]\n");
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }
    }
