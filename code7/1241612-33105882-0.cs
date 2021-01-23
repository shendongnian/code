            Rectangle imageRectangle = new Rectangle(southWest.X, northEast.Y, (northEast.X - southWest.X), (southWest.Y - northEast.Y));
            var bmp = new Bitmap(imageRectangle.Width, imageRectangle.Height);
            using (var gr = Graphics.FromImage(bmp))
            {
                gr.DrawImage(AP.Image, 0, 0, imageRectangle, GraphicsUnit.Pixel);
            }
            AP.Image = bmp;
