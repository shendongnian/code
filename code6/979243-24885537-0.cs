      // this will change the Image of a PictureBox, assuming it has one.
      // These changes are persistent:
        using (Graphics G = Graphics.FromImage(pictureBox1.Image))
        {
            G.DrawEllipse(Pens.Red, new Rectangle(0, 0, 444, 444));
            pictureBox1.Invalidate();
        }
      // This is the wrong, non-persistent way to paint, no matter which control: 
      //The changes go away whenever the Window is invalidated:
        using (Graphics G = pictureBox2.CreateGraphics() )
        {
            G.DrawEllipse(Pens.Green, new Rectangle(0, 0, 444, 444));
        }
