    private void MoveBlock(Label block, Label endBlock = null)
    {
        block.MouseDown += (ss, ee) =>
        {
            if (ee.Button == System.Windows.Forms.MouseButtons.Left) 
                fPoint = Control.MousePosition;
        };
        block.MouseMove += (ss, ee) =>
        {
            if (ee.Button == System.Windows.Forms.MouseButtons.Left)
            {
                Point temp = Control.MousePosition;
                Point res = new Point(fPoint.X - temp.X, fPoint.Y - temp.Y);
                block.Location = new Point(block.Location.X - res.X,
                                           block.Location.Y - res.Y);
                fPoint = temp;
                drawLines();   // <------- draw the new lines
            }
        };
    }
