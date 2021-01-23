    public partial class Form2 : Window
    {
        Form1 frm;
        public Form2()
        {
            InitializeComponent();
        }
        public Form2(Form1 frm)
        {
            InitializeComponent();
            this.frm = frm;
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            frm.Close();
        }
    }
