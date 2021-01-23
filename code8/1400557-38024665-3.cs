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
		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			// Code to draw tree view.
		}
	
		private TreeView binaryTreeViewData = new TreeView();
	}
