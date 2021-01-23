    Image<Bgr, byte> Img_Result_Bgr = Img_Source_Bgr.Copy();
    Image<Gray, byte> Img_Org_Gray = Img_Source_Bgr.Convert<Gray, byte>();
    Image<Gray, byte> Img_CannyEdge_Gray = new Image<Gray, byte>(Img_Source_Bgr.Width,Img_Source_Bgr.Height);
    
    Img_CannyEdge_Gray = Img_Org_Gray.Canny(10, 50);
    Img_Org_Gray.Dispose();
    
    Random Rnd = new Random();
    
    #region Finding Contours
    using (MemStorage storage = new MemStorage()) //allocate storage for contour approximation
    	for (Contour<Point> contours = Img_CannyEdge_Gray.FindContours(); contours != null; contours = contours.HNext)
    	{
    		Contour<Point> currentContour = contours.ApproxPoly(contours.Perimeter * 0.05, storage);//if you want to Approximate the contours into a polygon play with this function().
    
    		if (contours.Area > 100) //only consider contours with area greater than 100
    		{
    			Img_Result_Bgr.Draw(contours, new Bgr(Rnd.Next(255),Rnd.Next(255),Rnd.Next(255)), 2);
    		}
    	}
    #endregion
    Img_CannyEdge_Gray.Dispose();
    
    imageBox1.Image = Img_Result_Bgr; 
