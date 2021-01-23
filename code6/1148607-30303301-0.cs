        Image<Gray, byte> grayImage = new Image<Gray, byte>(colorImage);
        Image<Bgr, byte> color = new Image<Bgr, byte>(colorImage);
        grayImage = grayImage.ThresholdBinary(new Gray(thresholdValue), new Gray(255));
        using (MemStorage store = new MemStorage())
        for (Contour<Point> contours= grayImage.FindContours(Emgu.CV.CvEnum.CHAIN_APPROX_METHOD.CV_CHAIN_APPROX_NONE, Emgu.CV.CvEnum.RETR_TYPE.CV_RETR_TREE, store); contours != null; contours = contours.HNext)
        {
            Rectangle r = CvInvoke.cvBoundingRect(contours, 1);
            
            // filter contours by position and size of the box
        }
        
        // crop the image using found bounding box
