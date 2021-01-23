      public partial class Form1 : Form
      {
        Log log;
        public Form1()
        {
            InitializeComponent();
            log = new Log(richTextBox1);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }
        private void button1_Click(object sender, EventArgs e)
        {
            log.AddLog(DateTime.Now.ToString());
        }
        private void button2_Click(object sender, EventArgs e)
        {
            log.AddLog();
        }
    }
    public class Log
    {
        RichTextBox rtb;
        public Log(RichTextBox rtb)
        {
            this.rtb = rtb;
        }
        public void AddLog(string msg)
        {
            rtb.Text += msg + Environment.NewLine;
        }
        public void AddLog()
        {
            rtb.Text += DateTime.Now.ToString() + Environment.NewLine;
        }
    }
