    public partial class FontEditor : Form
    {
        public FontEditor(Font myFont)
        {
            InitializeComponent();
            propertyGrid1.SelectedObject = myFont;
        }
        private void FontEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
        public Font UpdatedFont
        {
            get { return propertyGrid1.SelectedObject as Font; }
        }
    }
