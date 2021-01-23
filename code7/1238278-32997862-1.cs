    private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
    {
        if (e.Button == System.Windows.Forms.MouseButtons.Left)
        {
            Point tempEndPoint = e.Location;
            var point1 = new Point(
                Math.Max(0, Math.Min(RectStartPoint.X, tempEndPoint.X)),
                Math.Max(0, Math.Min(RectStartPoint.Y, tempEndPoint.Y)));
            var point2 = new Point(
                Math.Min(this.picImagem.Width, Math.Max(RectStartPoint.X, tempEndPoint.X)),
                Math.Min(this.picImagem.Height, Math.Max(RectStartPoint.Y, tempEndPoint.Y)));
            Rect.Location = point1;
            Rect.Size = new Size(point2.X - point1.X, point2.Y - point1.Y);
            picImagem.Refresh();
            picImagem.CreateGraphics().DrawRectangle(cropPen, Rect);
        }
    }
