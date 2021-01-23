           int iTilesPerWidth = 5; 
            //create a bitmap to hold the combined image
            Bitmap finalImage = new System.Drawing.Bitmap(width, height);
            //get a graphics object from the image so we can draw on it
            using (System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(finalImage))
            {
                PointF point1 = new PointF(0, 0);
                int nCount = 1;
                foreach (Bitmap BM in lstImages)
                {
                    //512, 256
                    g.DrawImage(BM, point1);
                    point1.X += BM.Width;
                    if (nCount % iTilesPerWidth == 0)
                    {
                        point1.X = 0;
                        point1.Y += BM.Height;
                    }
                    nCount++;
                }
            }
            return finalImage;
        }
