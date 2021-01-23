    using System.ComponentModel;
    using System.Windows.Forms;
    using System.Windows.Forms.Design;
    [Designer(typeof(UserControl1Designer))]
    public partial class UserControl1 : UserControl
    {
        public UserControl1() { InitializeComponent(); }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public TabControl MyTabControl 
        {
           get { return this.tabControl1; } 
        }
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.SuspendLayout();
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Dock = DockStyle.Fill;
            this.Controls.Add(this.tabControl1);
            this.Name = "UserControl1";
            this.ResumeLayout(true);
        }
        private System.Windows.Forms.TabControl tabControl1;
    }
