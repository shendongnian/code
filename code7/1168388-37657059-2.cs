    using System.Windows.Forms;
    using System.ComponentModel;
    using System.Windows.Forms.Design;
    [Designer(typeof(ControlDesigner))]
    public class MyToolStrip : ToolStrip
    {
        private ToolStripButton toolStripButton1;
        public MyToolStrip()
        {
            InitializeComponent();
        }
    
        [Browsable(false)]
        public override ToolStripItemCollection Items
        {
            get
            {
                return base.Items;
            }
        }
    
        private void InitializeComponent()
        {
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.SuspendLayout();
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(80, 22);
            this.toolStripButton1.Text = "Some Button";
            this.toolStripButton1.Click += 
                            new System.EventHandler(this.toolStripButton1_Click);
            // 
            // MyToolStrip
            // 
            this.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1});
            this.ResumeLayout(false);
        }
    
        private void toolStripButton1_Click(object sender, System.EventArgs e)
        {
            MessageBox.Show("Some Button Clicked");
        }
    }
