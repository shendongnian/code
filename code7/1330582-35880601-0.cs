    public partial class Form1 : Form
    {
        public Form1(TextBox txt)
        {
            InitializeComponent();
            this.txt = txt;
        }
        //variable
        TextBox txt = null;
        private void button1_Click(object sender, EventArgs e)
        {
            txt.Text = "Your text";
        }
    }
