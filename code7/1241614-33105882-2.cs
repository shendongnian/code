        private Point pt1, pt2;
        private void AP_Click(object sender, EventArgs e)
        {
            // ... obviously other code here ...            
            else if (mark_shape == 0) // Setting the corners
            {
                Point pt = AP.PointToClient(Cursor.Position);
                if (picture_corners_set == 0)
                {
                    pt1 = new Point(pt.X, pt.Y);
                    picture_corners_set = 1;
                }
                else if (picture_corners_set == 1)
                {
                    pt2 = new Point(pt.X, pt.Y);
                    picture_corners_set = 0;
                    Rectangle imageRectangle = new Rectangle(new Point(Math.Min(pt1.X, pt2.X), Math.Min(pt1.Y, pt2.Y)), new Size(Math.Abs(pt2.X - pt1.X) + 1, Math.Abs(pt2.Y - pt1.Y) + 1));
                    var bmp = new Bitmap(imageRectangle.Width, imageRectangle.Height);
                    using (var gr = Graphics.FromImage(bmp))
                    {
                        gr.DrawImage(AP.Image, 0, 0, imageRectangle, GraphicsUnit.Pixel);
                    }
                    AP.Image = bmp;
                    enableAllButtons();
                }
            }
        }
