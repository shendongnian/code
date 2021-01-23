    class MyTreeView : TreeView
    {
    	const int WM_CONTEXTMENU = 0x007B;
    	protected override void WndProc(ref Message m)
    	{
    		if (m.Msg == WM_CONTEXTMENU && (long)m.LParam == -1 && this.ContextMenu != null)
    		{
    			var selectedNode = this.SelectedNode;
    			if (selectedNode == null) return;
    			var rect = selectedNode.Bounds;
    			var pt = new Point(rect.X + rect.Width / 2, rect.Y + rect.Height / 2);
    			if (!this.ClientRectangle.Contains(pt)) return;
    			this.ContextMenu.Show(this, pt);
    			return;
    		}
    		base.WndProc(ref m);
    	}
    }
