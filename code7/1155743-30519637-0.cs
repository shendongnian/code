    public partial class Form1 : Form
    {
        System.IO.StreamReader sr;
        System.IO.StreamWriter sw;
        public Form1()
        {
            InitializeComponent();
            radioButton1.Checked = true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                if (System.IO.File.Exists("C:\\testfile.txt"))
                {
                    try
                    {
                        sr = new System.IO.StreamReader("C:\\testfile.txt");
                        while (!sr.EndOfStream)
                        {
                            textBox1.Text += sr.ReadLine() + "\r\n";
                        }
                    }
                    finally 
                    {
                        sr.Close();
                        sr.Dispose();
                    }
                }
            }
            if (radioButton2.Checked == true)
            {
                if (System.IO.File.Exists("C:\\testfile.txt"))
                {
                    try
                    {
                        sw = new System.IO.StreamWriter("C:\\testfile.txt", true);
                        string result = textBox1.Text;
                        string[] lststr = result.Split(new Char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (string s in lststr)
                        {
                            sw.WriteLine(s);
                        }
                    }
                    finally 
                    {
                        sw.Flush();
                        sw.Close();
                        sw.Dispose();
                    }
                }
            }
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox1.ReadOnly = true;
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox1.ReadOnly = false;
        }
    }
