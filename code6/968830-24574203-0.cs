    Image<Bgr, Byte> image = Img_Source_Bgr.Copy();
    Image<Gray, Int32> marker = new Image<Gray, Int32>(image.Width, image.Height);
    Rectangle rect = image.ROI;
    marker.Draw(
    new CircleF(
    new PointF(rect.Left + rect.Width / 2.0f, rect.Top + rect.Height / 2.0f),
    	/*(float)(Math.Min(image.Width, image.Height) / 20.0f)*/ 5.0f),
    new Gray(255),
    0);
    Image<Bgr, Byte> result = image.ConcateHorizontal(marker.Convert<Bgr, byte>());
    Image<Gray, Byte> mask = new Image<Gray, byte>(image.Size);
    CvInvoke.cvWatershed(image, marker);
    CvInvoke.cvCmpS(marker, 0.10, mask, CMP_TYPE.CV_CMP_GT);
    
    imageBox1.Image = mask;
