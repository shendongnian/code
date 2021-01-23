    private void takeShotMenuItem_Click(object sender, EventArgs e)
        {
            Point start = imageOriginalPicBox.PointToScreen(Point.Empty);
            Point end = new Point(imageOriginalPicBox.PointToScreen(Point.Empty).X + imageOriginalPicBox.Width, imageOriginalPicBox.PointToScreen(Point.Empty).Y + imageOriginalPicBox.Height);
            TakeScreenShot(start, end);
 
        }
