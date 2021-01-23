    using System;
    using System.Linq;
    using System.Drawing;
    using System.Windows.Forms
    
    public class BinaryTreeView : Panel
    {
        List<string> nodes = new string<bool>();
	    List<Point> nodesPos = new string<Point>();
        protected overrides OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            // Code to draw tree view.
        }
    }
