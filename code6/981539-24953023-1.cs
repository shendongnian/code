    public partial class Form_Log : Form
    {
        private Form_Main _mainForm;
        public Form_Log(Form_Main _f1)
        {
           InitializeComponent();
           _mainForm = _f1;
        }
        private void Form1_FormClosing(Object sender, FormClosingEventArgs e)
        {
          _mainForm.folderList.Clear();
        }
     }
