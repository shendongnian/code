    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        private void Form2_VisibleChanged(object sender, EventArgs e)
        {
            if(this.Visible == true)
                MessageBox.Show("Hey");
        }
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();           
        }
    }
