	using System;
	using System.Linq;
	using System.Drawing;
	using System.Windows.Forms;
	using System.Collections.Generic;
	
	public class BinaryTreeView : Panel
	{	
		public BinaryTreeView()
		{
			this.Location = new Point(2, 2);
			this.Size = new Size(500, 400);
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
			// find and remove code.
			this.Refresh();
		}
		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			
			List<TreeNode> childNodes = new List<TreeNode>();
			for (int i = (binaryTreeViewData.Nodes.Count - 1); i > -1; i--)
			{
				Point nodePos = new Point(((this.Width - (55 * binaryTreeViewData.Nodes.Count)) / 2) + (i * 55), 5);
				e.Graphics.DrawEllipse(new Pen(new SolidBrush(Color.Black), 3), new Rectangle(nodePos.X, nodePos.Y, 50, 50));
				e.Graphics.DrawString(binaryTreeViewData.Nodes[i].Name, this.Font, new SolidBrush(this.ForeColor), nodePos.X + 11, nodePos.Y + 9);
				
				foreach (TreeNode childNode in binaryTreeViewData.Nodes[i].Nodes)
				{
					childNodes.Add(childNode);
				}
			}
			
			// Child node drawing part.
			List<TreeNode> childNodes2 = new List<TreeNode>();
			childNodes.Reverse();
			
			for (int i = (childNodes.Count - 1); i > -1; i--)
			{
				Point nodePos = new Point(((this.Width - (55 * childNodes.Count)) / 2) + (i * 55), 65);
				e.Graphics.DrawEllipse(new Pen(new SolidBrush(Color.Black), 3), new Rectangle(nodePos.X, nodePos.Y, 50, 50));
				e.Graphics.DrawString(childNodes[i].Name, this.Font, new SolidBrush(this.ForeColor), nodePos.X + 11, nodePos.Y + 9);
		
				foreach (TreeNode childNode in childNodes[i].Nodes)
				{
					childNodes2.Add(childNode);
				}
			}
			
			List<TreeNode> childNodes3 = new List<TreeNode>();
			childNodes2.Reverse();
			
			for (int i = (childNodes2.Count - 1); i > -1; i--)
			{
				Point nodePos = new Point(((this.Width - (55 * childNodes2.Count)) / 2) + (i * 55), 125);
				e.Graphics.DrawEllipse(new Pen(new SolidBrush(Color.Black), 3), new Rectangle(nodePos.X, nodePos.Y, 50, 50));
				e.Graphics.DrawString(childNodes2[i].Name, this.Font, new SolidBrush(this.ForeColor), nodePos.X + 11, nodePos.Y + 9);
				
				foreach (TreeNode childNode in childNodes2[i].Nodes)
				{
					childNodes3.Add(childNode);
				}
			}
			
			childNodes3.Reverse();
			
			for (int i = (childNodes3.Count - 1); i > -1; i--)
			{
				Point nodePos = new Point(((this.Width - (55 * childNodes3.Count)) / 2) + (i * 55), 185);
				e.Graphics.DrawEllipse(new Pen(new SolidBrush(Color.Black), 3), new Rectangle(nodePos.X, nodePos.Y, 50, 50));
				e.Graphics.DrawString(childNodes3[i].Name, this.Font, new SolidBrush(this.ForeColor), nodePos.X + 11, nodePos.Y + 9);
			}
		}
	
		private TreeView binaryTreeViewData = new TreeView();
	}
