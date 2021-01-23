    private void pictureBox1_Paint(object sender, PaintEventArgs e)
    {
        using (Bitmap needle =  new Bitmap("D:\\needle3.png" )  )
        {
            int angle = trBar_angle.Value;
            label1.Text = angle.ToString("###0°");
            // this is the offset after the translation
            Point targetPoint = new Point(-needle.Width / 2, needle.Width / 2);
            // shortcuts for the sizes
            Size nSize = needle.Size;
            Size pSize = pictureBox1.ClientSize;
            // this is the translation of the graphic to meet the rotation point
            int transX = pSize.Width / 2;
            int transY = pSize.Height - nSize.Width / 2;
            //set the rotation point and rotate
            e.Graphics.TranslateTransform( transX, transY );
            e.Graphics.RotateTransform(angle + 90); 
            // draw on the rotated graphics
            e.Graphics.DrawImage(needle, targetPoint);
            //reset everything
            e.Graphics.RotateTransform( -angle - 90); 
            e.Graphics.TranslateTransform( -transX, -transY );
        }
    }
