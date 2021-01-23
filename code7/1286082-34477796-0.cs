    public partial class MyTreeView : TreeView
    {
        public event TreeViewEventHandler SelectedNodeChanged;
        public MyTreeView()
        {
            this.AfterSelect += new TreeViewEventHandler(SelectNodeChangedEvent);
            this.MouseUp += new MouseEventHandler(MouseUpEvent);
        }
        void SelectNodeChangedEvent(object sender, TreeViewEventArgs e)
        { SelectedNodeChangedTrigger(sender, e); }
        void MouseUpEvent(object sender, MouseEventArgs e)
        {
        if (this.SelectedNode == null)
            SelectedNodeChangedTrigger(sender, new TreeViewEventArgs(null));
        }
        void SelectedNodeChangedTrigger(object sender, TreeViewEventArgs e)
        {
            if (SelectedNodeChanged != null)
                SelectedNodeChanged(sender, e);
        }
    }
