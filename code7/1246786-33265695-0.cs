    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public void ShowMessage(string message)
        {
            MessageLabel.Text = message;
        }
        private void ShowForm2(object sender, EventArgs e)
        {
            Form2 Form2Copy = new Form2(this);
            Form2Copy.ShowDialog();
        }
    }
