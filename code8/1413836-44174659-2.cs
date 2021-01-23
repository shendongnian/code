    public partial class ChildForm : Form , IChildView
        {
            public ChildForm()
            {
                InitializeComponent();
            }
    
            public bool ShowAsDialog()
            {
                throw new NotImplementedException();
            }
    
    
            public object MDIparent
            {
                set
                {
                    this.MdiParent = (Form)value;
                }
            }
        }
