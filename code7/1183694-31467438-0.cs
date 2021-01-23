    public List<Rectangle> detectLetters(Image<Bgr, Byte> img)
    {
        List<Rectangle> rects = new List<Rectangle>();
        Image<Gray, Single> img_sobel;
        Image<Gray, Byte> img_gray, img_threshold;
        img_gray = img.Convert<Gray, Byte>();
        img_sobel = img_gray.Sobel(1,0,3);
        img_threshold = new Image<Gray, byte>(img_sobel.Size);
        CvInvoke.cvThreshold(img_sobel.Convert<Gray, Byte>(), img_threshold, 0, 255, Emgu.CV.CvEnum.THRESH.CV_THRESH_OTSU);
        StructuringElementEx element = new StructuringElementEx(3, 17, 1, 6, Emgu.CV.CvEnum.CV_ELEMENT_SHAPE.CV_SHAPE_RECT);
        CvInvoke.cvMorphologyEx(img_threshold, img_threshold, IntPtr.Zero, element, Emgu.CV.CvEnum.CV_MORPH_OP.CV_MOP_CLOSE, 1);
        for (Contour<System.Drawing.Point> contours = img_threshold.FindContours(); contours != null; contours = contours.HNext)
        {
            if (contours.Area > 100)
            {
                Contour<System.Drawing.Point> contours_poly = contours.ApproxPoly(3);
                rects.Add(new Rectangle(contours_poly.BoundingRectangle.X, contours_poly.BoundingRectangle.Y, contours_poly.BoundingRectangle.Width, contours_poly.BoundingRectangle.Height));
            }
        }
        return rects;
    }
