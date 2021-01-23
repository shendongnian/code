     if (FileUpload1.HasFile)
            {
                string imageFile = FileUpload1.FileName;
                string path = Server.MapPath("~/images/galeria/" + imageFile);
                FileUpload1.SaveAs(path);
                System.Drawing.Image image = System.Drawing.Image.FromFile(path);
                float aspectRatio = (float)image.Size.Width / (float)image.Size.Height;
                int newHeight = 200;
                int newWidth = Convert.ToInt32(aspectRatio * newHeight);
                System.Drawing.Bitmap thumbBitmap = new System.Drawing.Bitmap(newWidth, newHeight);
                System.Drawing.Graphics thumbGraph = System.Drawing.Graphics.FromImage(thumbBitmap);
                thumbGraph.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                thumbGraph.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                thumbGraph.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                var imageRectangle = new Rectangle(0, 0, newWidth, newHeight);
                thumbGraph.DrawImage(image, imageRectangle);
                thumbBitmap.Save(Server.MapPath("~/images/galeria/thumb/" + FileUpload1.FileName), System.Drawing.Imaging.ImageFormat.Jpeg);
                thumbGraph.Dispose();
                thumbBitmap.Dispose();
                image.Dispose();
            }
