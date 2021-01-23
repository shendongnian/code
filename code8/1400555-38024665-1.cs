    using System;
    using System.Linq;
    using System.Drawing;
    using System.Windows.Forms;
    using System.Collections.Generic;
    
    public class BinaryTreeView : Panel
    {
        private List<string[]> nodes = new List<string[]>();
        private List<Point> nodesPos = new List<Point>();
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            // Code to draw tree view.
        }
    }
