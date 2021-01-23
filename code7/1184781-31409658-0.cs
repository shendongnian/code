Form1.cs
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void LaunchForm2()
        {
            using (var form2 = new Form2())
            {
                form2.OnTextEnteredHandler += Form2_OnTextEnteredHandler;
                form2.ShowDialog();
            }
        }
        private void Form2_OnTextEnteredHandler(string text)
        {
            textBox1.Text = text;
        }
    }
Form2.cs
    public partial class Form2 : Form
    {
        public delegate void TextEnteredHandler(string text);
        public event TextEnteredHandler OnTextEnteredHandler;
        public Form2()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (OnTextEnteredHandler != null)
            {
                OnTextEnteredHandler(textBox1.Text);
                Close();
            }
        }
    }
