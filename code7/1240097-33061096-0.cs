    public partial class Form1 : Form
    {
        private int index;
        public Form1()
        {
            InitializeComponent();
            ResetForm();
        }
        private void ResetForm()
        {
            index = 1;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            TextBox tb = this.Controls.Find("tbOutput" + index.ToString(), false).OfType<TextBox>().FirstOrDefault();
            if(tb!= null)
            {
                tb.Text = tbInput.Text;
            }
            index++;
            if (index > 5)
                ResetForm();
        }
    }
