    public partial class frm_Settings : Form
    {
        private frm_Main _main;
        public frm_Settings(frm_Main main)
        {
              _main = main;
        }
    
        private void pbcl_editorBackColor_Click(object sender, EventArgs e)
        {
            ColorDialog editorBackColor = new ColorDialog();
            if (editorBackColor.ShowDialog() == DialogResult.OK)
            {
                Variables.Editor_BackColor = "#" + editorBackColor.Color.ToArgb().ToString("X");
                Color colour = ColorTranslator.FromHtml(Variables.Editor_ForeColor);                
                _main.ChangeBackColor(colour);
            }
        }
    }
