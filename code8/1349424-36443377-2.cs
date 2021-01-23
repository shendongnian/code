    public partial class Form2 : Form
    {
        private TextBox _OwnerTextBox;
        public Form2(TextBox ownerTextBox)
        {
            InitializeComponent();
            _OwnerTextBox = ownerTextBox;
            this.textBox1.Text = _OwnerTextBox.Text;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            _OwnerTextBox.Text = this.textBox1.Text;
        }
    }
