    public partial class MyControl1 : UserControl
    {
        public MyControl1() { InitializeComponent(); }
        public string TextBox1Text
        {
            get { return this.textBox1.Text; }
            set { this.textBox1.Text = value; }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (Parent != null)
            {
                var control1 = Parent.Controls.OfType<MyControl2>().FirstOrDefault();
                if (control1 != null && control1.TextBox1Text != this.textBox1.Text)
                    control1.TextBox1Text = this.textBox1.Text;
            }
        }
    }
