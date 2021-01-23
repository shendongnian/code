    public partial class MyTreeView : UserControl
    {
        public delegate void ValueSelectedHandler(object sender, EventArgs e, string value);
        public event ValueSelectedHandler OnValueSelected;
        private string _nodeName;
        public string NodeName { get { return _nodeName;} }
    
        public MyTreeView()
        {
            InitializeComponent();
        }
    
        private void trv_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node == null || e.Node.Parent == null || e.Node.Parent.Parent == null)
                return;
    
            nodeName = e.Node.Parent.Parent.Text + @"\" + e.Node.Parent.Text + @"\" + e.Node.Text;
            if(OnValueSelected!=null)
            {
                OnValueSelected(sender, e, nodeName);
            }
        }    
    }
