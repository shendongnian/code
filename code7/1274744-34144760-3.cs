    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        if (allTrue()) //If tic tac toe is detected
            e.Graphics.DrawLine(new Pen(Color.Red, 10), new Point(0, 0), new Point(140, 100));
    }
    private void Form1_Click(object sender, EventArgs e)
    {
        if (allTrue()) //If you click the form after we drew our line, reset
        {
            ab1 = false;
            ab2 = false;
            ab3 = false;
            this.Invalidate(); //We can call this whenever we want to redraw the form
        }
    }
