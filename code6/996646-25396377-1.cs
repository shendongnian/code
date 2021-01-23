        Boolean bHaveMouse;
        Point ptOriginal = new Point();
        Point ptLast = new Point();
        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            bHaveMouse = true;
            // Store the "starting point" for this rubber-band rectangle.
            ptOriginal.X = e.X;
            ptOriginal.Y = e.Y;
            // Special value lets us know that no previous
            // rectangle needs to be erased.
            ptLast.X = -1;
            ptLast.Y = -1;
        }
        // Convert and normalize the points and draw the reversible frame.
        private void MyDrawReversibleRectangle(Point p1, Point p2)
        {
            Rectangle rc = new Rectangle();
            // Convert the points to screen coordinates.
            p1 = pictureBox.PointToScreen(p1);
            p2 = pictureBox.PointToScreen(p2);
            // Normalize the rectangle.
            if (p1.X < p2.X)
            {
                rc.X = p1.X;
                rc.Width = p2.X - p1.X;
            }
            else
            {
                rc.X = p2.X;
                rc.Width = p1.X - p2.X;
            }
            if (p1.Y < p2.Y)
            {
                rc.Y = p1.Y;
                rc.Height = p2.Y - p1.Y;
            }
            else
            {
                rc.Y = p2.Y;
                rc.Height = p1.Y - p2.Y;
            }
            // Draw the reversible frame.
            rect = new Rectangle(pictureBox.PointToClient(rc.Location), rc.Size);
            ControlPaint.DrawReversibleFrame(rc, Color.Gray, FrameStyle.Dashed);
        }
        Rectangle rect = Rectangle.Empty;
        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            // Set internal flag to know we no longer "have the mouse".
            bHaveMouse = false;
            // If we have drawn previously, draw again in that spot
            // to remove the lines.
            if (ptLast.X != -1)
            {
                Point ptCurrent = new Point(e.X, e.Y);
                MyDrawReversibleRectangle(ptOriginal, ptLast);
            }
            // Set flags to know that there is no "previous" line to reverse.
            ptLast.X = -1;
            ptLast.Y = -1;
            ptOriginal.X = -1;
            ptOriginal.Y = -1;
            pictureBox.Invalidate();
        }
        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            if (rect.Width > 10 && rect.Height > 10)
            {
                e.Graphics.DrawRectangle(Pens.Gray, rect);
                pictureBox1.Image =  CropImage();
            }
        }
        private Bitmap CropImage()
        {
            Bitmap pic = pictureBox.Image as Bitmap;
            Bitmap cropped = new Bitmap(rect.Width, rect.Height);
            using (Graphics g = Graphics.FromImage(cropped))
            {
                g.DrawImage(pic, new Rectangle(0, 0, rect.Width, rect.Height),
                             rect, GraphicsUnit.Pixel);
            }
            return cropped;
        }
        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            Point ptCurrent = new Point(e.X, e.Y);
            // If we "have the mouse", then we draw our lines.
            if (bHaveMouse)
            {
                // If we have drawn previously, draw again in
                // that spot to remove the lines.
                if (ptLast.X != -1)
                {
                    MyDrawReversibleRectangle(ptOriginal, ptLast);
                }
                // Update last point.
                ptLast = ptCurrent;
                // Draw new lines.
                MyDrawReversibleRectangle(ptOriginal, ptCurrent);
            }
        }
