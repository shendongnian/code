    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.textBox1.Text = "Default";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            switch (comboBox2.SelectedIndex)
            {
                case -1:
                    MessageBox.Show("You didn't choose anything.");
                    break;
                case 0:
                    Form2 form_Form2 = new Form2(this.textBox1.Text);
                    if (form_Form2.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        this.textBox1.Text = form_Form2.Value;
                    }
                    break;
            }
        }
    }
    public partial class Form2 : Form
    {
        private Form2() { }
        public string Value
        {
            get
            {
                return this.textBox1.Text;
            }
        }
        public Form2(string currentValue)
        {
            InitializeComponent();
            this.textBox1.Text = currentValue;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
