    public partial class formOpConfig : Form
    {
        private Form1 Opener { get; set; }
        public formOpConfig(Form1 opener)
        { 
            Opener = opener;
        }
       
        private void updateForm1()
        {
            Opener.updatedata();
        }
    }
