    public class Servers
    {
        private Form _frmMain;
        public Servers(Form frmMain)
        {
            _frmMain = frmMain;
        }
        public void _SetlabelText()
        {
            _frmMain.label1.Text = "New Text";
        }
    }
