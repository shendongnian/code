    private void ShapesPanel_Paint(object sender, PaintEventArgs e)
    {
        foreach (var shape in _shapes)
        {
            shape.DrawAble(e.Graphics);
        }    
    }
    
    // in the Shape class
    public void DrawAble(Graphics g)
    {
        var pen = new Pen(this.Color, 3);
        g.DrawRect( ... ); // or whatever
    }
