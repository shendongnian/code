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
			this.Font = new Font(this.Font.Name, 21f, FontStyle.Bold);
		}
		
		public void AddParent(string nodeName)
		{
			binaryTreeViewData.Nodes.Add(new TreeNode() { Name = nodeName });
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
			this.Refresh();
		}
		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			for (int i = (binaryTreeViewData.Nodes.Count - 1); i > -1; i--)
			{
				Point nodePos = new Point(((this.Width - (55 * binaryTreeViewData.Nodes.Count)) / 2) + (i*55), 5);
				e.Graphics.DrawEllipse(new Pen(new SolidBrush(Color.Black), 3), new Rectangle(nodePos.X, nodePos.Y, 50, 50));
				e.Graphics.DrawString(binaryTreeViewData.Nodes[i].Name, this.Font, new SolidBrush(this.ForeColor), nodePos.X + 11, nodePos.Y + 9);
			}
		}
	
		private TreeView binaryTreeViewData = new TreeView();
	}
