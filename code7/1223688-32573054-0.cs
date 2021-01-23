        private void OnNodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (treeView1.SelectedNode == null)
                return;
            if (e.Button != MouseButtons.Right)
                return;
            MyObject targetObject = (MyObject)e.Node.Tag;
            if (targetObject == null)
                return;
            e.Node.ContextMenuStrip = MyObject.SharedPopup;
        }
