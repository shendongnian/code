    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public void loadwebpage(string link)
        {
            webBrowser1.Navigate(link);
        } 
        private void button1_Click(object sender, EventArgs e)
        {
            secondForm form2 = new secondForm(this);
            form2.Show();
        }
    }
