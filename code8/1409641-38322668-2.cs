    private void Form1_MouseDown(object sender, MouseEventArgs e)
    {
        GraphicsPath gp = new GraphicsPath();
        gp.AddRectanle(hitbox);
        using (Pen pen = new Pen(Color.Black, 2f))
          if (gp.IsOutlineVisible(e.location), pen)  ..  // clicked on outline 
    }
