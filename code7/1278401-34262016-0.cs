        public partial class Form1 : Form
    {
        public int i; 
   
        private Form1 _frmSelection;
        public Form1()
        {
            InitializeComponent();
            i = Application.OpenForms.Count;
        }
    private void _frmSelection_FormClosing(object sender, FormClosingEventArgs e)
        {
            _frmSelection = null;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
            if (_frmSelection == null)
            {
                _frmSelection = new Form1();
             
                _frmSelection.FormClosing += _frmSelection_FormClosing;
                _frmSelection.WindowState = FormWindowState.Minimized;
                _frmSelection.WindowState = FormWindowState.Normal;
                _frmSelection.Show();
                if (Application.OpenForms.Count > 1)
                {
                    _frmSelection.Text = Application.OpenForms[i].Text + " and going";
                }
      
             
            }
            else
            {
                _frmSelection.WindowState = FormWindowState.Minimized;
                _frmSelection.WindowState = FormWindowState.Normal;
        
            }
        }
    }
