    //  panning code
    if ( pflag == 1 && e.Button == System.Windows.Forms.MouseButtons.Left  )
    {
        {
            Rectangle panRect = new Rectangle(panel1.Location, panel1.ClientSize);
            Rectangle picRect = new Rectangle(pictureBox2.Location, pictureBox2.ClientSize);
            int newLeft = pictureBox2.Left + (e.Location.X - start.X);
            int newTop = pictureBox2.Top + (e.Location.Y - start.Y);
            int newRight = newLeft + picRect.Width;
            int newBottom = newTop + picRect.Height;
            if ((newLeft < 0 && newRight < panRect.Width)
            || (newLeft > 0 /*&& newRight > panRect.Width */)) newLeft = picRect.Left;
            if ((newTop < 0 && newBottom < panRect.Width)
            || (newTop > 0 /*&& newBottom > panRect.Height*/)) newTop = picRect.Top;
            pictureBox2.Location = new Point(newLeft, newTop);
        }
        Text = "" + pictureBox2.Location;
    }
