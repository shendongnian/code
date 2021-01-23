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
			foreach(TreeNode node in binaryTreeViewData.Nodes)
			{
				Point nodePos = new Point(5, 5);
				e.Graphics.DrawEllipse(new Pen(new SolidBrush(Color.Black), 3), new Rectangle(nodePos.X, nodePos.Y, 50, 50));
				e.Graphics.DrawString(node.Name, this.Font, new SolidBrush(this.ForeColor), nodePos.X + 25, nodePos.Y + 25);
			}
		}
	
		private TreeView binaryTreeViewData = new TreeView();
	}
