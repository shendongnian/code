    public partial class Form1 : Form
    {
        UserControl1 UC1;
        public Form1()
        {
            InitializeComponent();
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            if (UC1 == null)
            {
                UC1 = new UserControl1(textBox1);
                //Add event handler
                UC1.UISendTextHandlerUC += FinallyWeGetTheString;
            }
            Controls.Add(UC1);
            UC1.Visible = true;
        }
    
        //New
        void FinallyWeGetTheString(string YourStringFromTextBox)
        {
             textBox1.Text = YouStringFromTextBox;
        }
    }
