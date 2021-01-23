        private void OnNodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (treeView1.SelectedNode == null)
                return;
            if (e.Button != MouseButtons.Right)
                return;
            MyObject targetObject = (MyObject)e.Node.Tag;
            if (targetObject == null)
                return;
            var point = new Point(e.X + 20, e.Y);
            var popupMenu = targetObject.PopupMenu;
            if (ContextMenuStrip != null)
            {
                ContextMenuStrip.Dispose();
            }
            ContextMenuStrip = popupMenu;
            ContextMenuStrip.Show(this, point);
        }
