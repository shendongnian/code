    public partial class Form1 : Form
    {
        double total = 0.0;
        double COOKIE_PRICE = 2.24;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.listBox1.Items.AddRange(new object[] { 0.5, 1.0, 2.0, 3.0 });
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                if (listBox1.SelectedItem != null)
                {
                    // (* 12.0) Because the value selected is number of dozen.
                    total = COOKIE_PRICE * ((double)listBox1.SelectedItem * 12.0);
                    MessageBox.Show(total.ToString());
                }
                else
                {
                    MessageBox.Show("Nothing was selected in the ListBox!");
                }
            }
        }
    }
