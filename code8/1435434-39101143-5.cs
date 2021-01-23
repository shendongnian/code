    using System.ComponentModel;
    using System.Windows.Forms;
    using System.Windows.Forms.Design;
    [Designer(typeof(MyUserControl2Designer))]
    public partial class UserControl2 : UserControl
    {
        public UserControl2() { InitializeComponent(); }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public TabControl MyTabControl
        { 
            get { return this.tabControl1; } 
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public TabPage T1 
        {
            get { return this.tabPage1; } 
        }
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Name = "tabControl1";
            this.Controls.Add(this.tabControl1);
            this.Name = "UserControl2";
            this.tabControl1.ResumeLayout(true);
            this.ResumeLayout(true);
        }
        private TabPage tabPage1;
        private System.Windows.Forms.TabControl tabControl1;
    }
<!---->
    public class MyUserControl2Designer : ParentControlDesigner
    {
        public override void Initialize(System.ComponentModel.IComponent component)
        {
            base.Initialize(component);
            this.EnableDesignMode(((UserControl2)this.Control).MyTabControl, "MyTabControl");
            this.EnableDesignMode(((UserControl2)this.Control).T1, "T1");
        }
    }
