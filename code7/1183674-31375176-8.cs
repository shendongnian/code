    public partial class frm_Settings : Form
    {
        public delegate void ColorChangedHandler(Color color);
        public event ColorChangedHandler OnColorChangedHandler;
        public frm_Settings()
        {
        }
    
        private void pbcl_editorBackColor_Click(object sender, EventArgs e)
        {
            ColorDialog editorBackColor = new ColorDialog();
            if (editorBackColor.ShowDialog() == DialogResult.OK)
            {
                Variables.Editor_BackColor = "#" + editorBackColor.Color.ToArgb().ToString("X");
                Color colour = ColorTranslator.FromHtml(Variables.Editor_ForeColor);
                if (OnColorChangedHandler != null)
                {
                   OnColorChangedHandler(colour);
                }
            }
        } 
    }
