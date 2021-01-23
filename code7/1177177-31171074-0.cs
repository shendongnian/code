    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (this.ActiveControl != null && this.ActiveControl is TextBox)
            {
                string replacement = "";
                TextBox tb = (TextBox)this.ActiveControl;
                bool useHTMLCodes = checkBoxUseHTMLCodes.Checked;
                if (keyData == (Keys.Control | Keys.A))
                {
                    replacement = useHTMLCodes ? "&aacute;" : "á";
                }
                else if (keyData == (Keys.Control | Keys.Shift | Keys.A))
                {
                    replacement = useHTMLCodes ? "&Aacute;" : "Á";
                }
                if (replacement != "")
                {
                    tb.SelectedText = replacement;
                    return true;
                }
            }
            
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
