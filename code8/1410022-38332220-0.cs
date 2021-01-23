     private void pic_Paint(object sender, PaintEventArgs e)
            {
                Graphics g = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;
    
                foreach (Point pt in points)
                {
                    Pen p = new Pen(Color.Tomato, 2);
                    g.DrawEllipse(p, pt.X, pt.Y, 20, 20);
                    g.FillEllipse(Brushes.Blue, pt.X, pt.Y, 20, 20);
                    p.Dispose();
                }
                
            }
