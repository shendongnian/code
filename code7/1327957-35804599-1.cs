    // on form, set form property KeyPreview to true
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        private void Form2_DoubleClick(object sender, EventArgs e)
        {
            this.Enabled = false;
        }
        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.Enabled = true;
            }
        }
    }
