    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                contextMenuStrip1.Renderer = new AccessKeyMenuStripRenderer();
            }
    
            private void Form1_Click(object sender, EventArgs e)
            {
                contextMenuStrip1.Show(Cursor.Position);
            }
        }
        
        class AccessKeyMenuStripRenderer : ToolStripSystemRenderer 
        {
            protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
            {
                e.TextFormat &= ~TextFormatFlags.HidePrefix;
                base.OnRenderItemText(e);
            }
        }
    }
