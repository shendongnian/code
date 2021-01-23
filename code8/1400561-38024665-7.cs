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
		public void Add(string nodeName, string parentNode)
		{
			try { binaryTreeViewData.Nodes.Find(parentNode, true)[0].Nodes.Add(new TreeNode() { Name = nodeName }); } catch { }
			this.Refresh();
		}
		
		public void Remove(string nodeName)
		{
			// add find and remove code...
			this.Refresh();
		}
		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			// parent nodes
			for (int i = (binaryTreeViewData.Nodes.Count - 1); i > -1; i--)
			{
				Point nodePos = new Point(((this.Width - (55 * binaryTreeViewData.Nodes.Count)) / 2) + (i*55), 5);
				e.Graphics.DrawEllipse(new Pen(new SolidBrush(Color.Black), 3), new Rectangle(nodePos.X, nodePos.Y, 50, 50));
				e.Graphics.DrawString(binaryTreeViewData.Nodes[i].Name, this.Font, new SolidBrush(this.ForeColor), nodePos.X + 11, nodePos.Y + 9);
				
				// fix child code.
				for (int j = binaryTreeViewData.Nodes[i].Nodes.Count; j > -1; j--)
				{
					Point nodePos2 = new Point(((this.Width - (55 * binaryTreeViewData.Nodes[i].Nodes.Count)) / 2) + (j*55), 60);
					e.Graphics.DrawEllipse(new Pen(new SolidBrush(Color.Black), 3), new Rectangle(nodePos2.X, nodePos2.Y, 50, 50));
					e.Graphics.DrawString(binaryTreeViewData.Nodes[i].Nodes[j].Name, this.Font, new SolidBrush(this.ForeColor), nodePos2.X + 11, nodePos2.Y + 9);
				}
			}
		}
	
		private TreeView binaryTreeViewData = new TreeView();
	}
