    public DevExReportSnapDesignerForm()
    {
        InitializeComponent();
        MenuCommandHandler menuCommandHandler = new CustomMenuCommandHandler(
            report,
            fieldListDockPanel1.Controls[0].Controls[0] as SnapFieldListTreeView);
        menuCommandHandler.RegisterMenuCommands();
        report.RemoveService(typeof(MenuCommandHandler));
        report.AddService(typeof(MenuCommandHandler), menuCommandHandler);
    }
    public class CustomMenuCommandHandler : MenuCommandHandler
    {
        SnapControl snapControl;
        private SnapFieldListTreeView treeView;
        public CustomMenuCommandHandler(SnapControl snap, SnapFieldListTreeView tree) : base(snap)
        {
            snapControl = snap;
            treeView = tree;
        }
        //Some stuff for MenuCommandHandler.
        //...
        public void RemoveDS_OnClick(object sender, EventArgs e)
        {
            var node = treeView.FocusedNode;//<= Here comes the selected DataSet's node.
            MessageBox.Show(node.GetDisplayText(""));
            //Remove Code
        }
    }
