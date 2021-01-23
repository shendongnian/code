    public class MifarePasswordForm
    {
        public int iD {get;set;} // or private field
    
        public MifarePasswordForm(int _iD)
        {
            InitializeComponent();
            iD = _iD; // here you don't create, only use
            textBox1.Text += iD;
        }
    
        private void btnOK_Click(object sender, EventArgs e)
        {
           //inside this method you can use this variable
    
           byte Oid = Convert.ToByte(iD);
        }
    }
