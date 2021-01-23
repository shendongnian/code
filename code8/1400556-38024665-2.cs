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
	
		public void Add(string nodeName, string nodeParentName = "")
		{
			nodes.Add(new string[] { nodeName, nodeParentName });
		}
		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			// Code to draw tree view.
		}
	
		private List<string[]> nodes = new List<string[]>();
		private List<Point> nodesPos = new List<Point>();
	}
