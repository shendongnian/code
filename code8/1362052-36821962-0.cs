            Bitmap bmpSave = new Bitmap(yourNewWidth, yourNewHeight);
            using (Graphics g = Graphics.FromImage(bmpSave))
            {
                  g.ScaleTransform(ratio * zoomFac, ratio * zoomFac);
                  g.DrawImage((Bitmap)pictureBox1.Image, 0, 0);  // 
                  pictureBox1.Image = bmpSave;
            }
