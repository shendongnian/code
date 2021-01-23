    private void pictureBoxSnap_MouseUp(object sender, MouseEventArgs e)
        {
            if (isCropped[listBoxSnap.SelectedIndex] == false && e.Button == MouseButtons.Left)
            {
                if (Math.Abs(e.Location.X - RectStartPoint.X) < 10 || Math.Abs(e.Location.Y - RectStartPoint.Y) < 10)
                {
                    rectangles[listBoxSnap.SelectedIndex] = new Rectangle(0, 0, 0, 0);
                    drawpicbox(listBoxSnap.SelectedIndex);
                }
                else
                {
                    ConfirmRectangle.Enabled = true;
                    rectangles[listBoxSnap.SelectedIndex] = new Rectangle(Math.Min(RectStartPoint.X, e.X), Math.Min(RectStartPoint.Y, e.Y),
                                    Math.Abs(RectStartPoint.X - e.X), Math.Abs(RectStartPoint.Y - e.Y));
                }
            }
        }
