    private void pnlDesign_MouseClick(object sender, MouseEventArgs e)
    {
        using (Brush brush = new SolidBrush(Color.Red))
        {
            g.FillRectangle(brush, listRec.Where(r => r.Contains(new Point { X = e.X, Y = e.Y })).First());
        }    
    }
