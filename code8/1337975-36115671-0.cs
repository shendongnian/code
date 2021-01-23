    public partial class Form1
    {
        private bool isDrawing;
        private Point startPoint;
        private Point currentPoint;
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            isDrawing = true;
            startPoint = e.Location; // remember the starting point
        }
        // subscribe this to the MouseUp event of Form1
        private void Form1_MouseUp(object sender, EventArgs e)
        {
            isDrawing = false;
            Invalidate(); // tell Form1 to redraw!
        }
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            currentPoint = e.Location; // save current point
            Invalidate(); // tell Form1 to redraw!
        }
        
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e); // call base implementation
            if (!isDrawing) return; // no line drawing needed
            // draw line from startPoint to currentPoint
            using (Pen bedp = new Pen(Color.Blue, 2))
                e.Graphics.DrawLine(bedp, startPoint, currentPoint);
        }
    }
