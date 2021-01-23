    using System.Windows.Forms;
    using System.ComponentModel.Design;
    public partial class MyBaseControl : UserControl
    {
        public MyBaseControl()
        {
            InitializeComponent();
        }
        public bool IsRootDesigner
        {
            get
            {
                var host = (IDesignerHost)this.GetService(typeof(IDesignerHost));
                if (host != null)
                    return host.RootComponent == this;
                return false;
            }
        }
    }
