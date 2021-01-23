        Image<Gray, byte> grayImage = new Image<Gray, byte>(colorImage);
        Image<Bgr, byte> color = new Image<Bgr, byte>(colorImage);
        Image<Bgr, byte> whiteconverter = new Image<Bgr, byte>(blankImage);
        grayImage = grayImage.ThresholdBinary(new Gray(0), new Gray(255));
        grayImage._Not();
        using (MemStorage storage = new MemStorage())
        {
            using (var p2 = new Pen(Color.Yellow, 2))
            {
                var grp = Graphics.FromImage(blankImage);
                for (Contour<Point> contours = grayImage.FindContours(Emgu.CV.CvEnum.CHAIN_APPROX_METHOD.CV_CHAIN_APPROX_NONE, 
                    Emgu.CV.CvEnum.RETR_TYPE.CV_RETR_LIST, storage); contours != null; contours = contours.HNext)
                {
                    foreach (var ctr in contours)
                    {
                        grp.DrawEllipse(p2, ctr.X, ctr.Y, 4, 4);
                    }
                    pictureBox3.Image = blankImage;
                }
            }
        }
