        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            MyDrawing(e.Graphics);
            Bitmap b = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.DrawToBitmap(b, pictureBox1.ClientRectangle);
            b.Save(@"C:\test.bmp");
        }
        private void MyDrawing(Graphics g)
        {
            var lastPoint = points[0];
            for (int i = 1; i < points.Count; i++)
            {
                var p = points[i];
                // When the user takes the pen off the device, X/Y is set to -1
                if ((lastPoint.X >= 0 || lastPoint.Y >= 0) && (p.X >= 0 || p.Y >= 0))
                    g.DrawLine(Pens.Black, lastPoint.X, lastPoint.Y, p.X, p.Y);
                lastPoint = p;
            }
            g.Flush();
        }
