	using System;
	using System.Linq;
	using System.Drawing;
	using System.Windows.Forms;
	using System.Collections.Generic;
	
	public class BinaryTreeView : Panel
	{	
		public BinaryTreeView()
		{
			this.Size = new Size(400, 400);
			this.BackColor = Color.White;
		}
		
		public void AddParent(string nodeName)
		{
			binaryTreeViewData.Nodes.Add(nodeName);
			this.Refresh();
		}
		public void Add(string nodeName, string parentNodeId)
		{
			binaryTreeViewData.Nodes.Find(parentNodeId, true)[0].Nodes.Add(parentNodeId);
			this.Refresh();
		}
		
		public void Remove(string nodeName)
		{
			binaryTreeViewData.Nodes.RemoveByKey(nodeName);
		}
		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			// Code to draw tree view.
		}
	
		private TreeView binaryTreeViewData = new TreeView();
	}
