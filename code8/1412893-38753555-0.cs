    private Rectangle GetViewRect() { return pictureBox1.ClientRectangle; }
    private void MainScreenThread()
    {
        ReadData();//reading data from socket.
        initial = bufferToJpeg();//first intial full screen image.
        pictureBox1.Paint += pictureBox1_Paint;//activating the paint event.
        // The update action
        Action<Rectangle> updateAction = imageRect =>
        {
            var viewRect = GetViewRect();
            var scaleX = (float)viewRect.Width / image.Width;
            var scaleY = (float)viewRect.Height / image.Height;
            // Make sure the target rectangle includes the new block
            var targetRect = Rectangle.FromLTRB(
                (int)Math.Truncate(imageRect.X * scaleX),
                (int)Math.Truncate(imageRect.Y * scaleY),
                (int)Math.Ceiling(imageRect.Right * scaleX),
                (int)Math.Ceiling(imageRect.Bottom * scaleY));
            pictureBox1.Invalidate(targetRect);
            pictureBox1.Update();
        };
        while (true)
        {
            int pos = ReadData();
            x = BlockX();//where to draw :X
            y = BlockY();//where to draw :Y
            Bitmap block = bufferToJpeg();//constantly reciving blocks.
            Draw(block, new Point(x, y));//applying the changes-drawing the block on the big initial image.using native memcpy.
            // Invoke the update action, passing the updated block rectangle
            this.Invoke(updateAction, new Rectangle(x, y, block.Width, block.Height));
        }
    }
    private void pictureBox1_Paint(object sender, PaintEventArgs e)
    {
        lock (initial)
        {
            var viewRect = GetViewRect();
            var scaleX = (float)image.Width / viewRect.Width;
            var scaleY = (float)image.Height / viewRect.Height;
            var targetRect = e.ClipRectangle;
            var imageRect = new RectangleF(targetRect.X * scaleX, targetRect.Y * scaleY, targetRect.Width * scaleX, targetRect.Height * scaleY);
            e.Graphics.DrawImage(initial, targetRect, imageRect, GraphicsUnit.Pixel);
        }
    }
