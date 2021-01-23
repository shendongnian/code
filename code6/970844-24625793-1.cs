    private void button2_Click(object sender, EventArgs e)
    {
    	Image<Gray, byte> Img_Scene_Gray = Img_Source_Bgr.Convert<Gray, byte>();
    	Image<Bgr, byte> Img_Result_Bgr = Img_Source_Bgr.Copy();
    	LineSegment2D MinIntersectionLineSegment = new LineSegment2D();
    	Img_Scene_Gray = Img_Scene_Gray.ThresholdBinary(new Gray(10), new Gray(255));
    
    	#region Finding Contours
    	using (MemStorage Scene_ContourStorage = new MemStorage())
    	{
    		for (Contour<Point> Contours_Scene = Img_Scene_Gray.FindContours(CHAIN_APPROX_METHOD.CV_CHAIN_APPROX_SIMPLE,
    					RETR_TYPE.CV_RETR_EXTERNAL, Scene_ContourStorage); Contours_Scene != null; Contours_Scene = Contours_Scene.HNext)
    		{
    			if (Contours_Scene.Area > 25)
    			{
    				if (Contours_Scene.HNext != null)
    				{
    					MinIntersectionLine(Contours_Scene, Contours_Scene.HNext, ref MinIntersectionLineSegment);
    					Img_Result_Bgr.Draw(MinIntersectionLineSegment, new Bgr(Color.Green), 2);
    				}
    				Img_Result_Bgr.Draw(Contours_Scene, new Bgr(Color.Red), 1);
    			}
    		}
    	}
    	#endregion
    	imageBox1.Image = Img_Result_Bgr;
    }
    void MinIntersectionLine(Contour<Point> a, Contour<Point> b,ref LineSegment2D Line)
    {
    	double MinDist = 10000000;
    	for (int i = 0; i < a.Total; i++)
    	{
    		for (int j = 0; j < b.Total; j++)
    		{
    			double Dist = Distance_BtwnPoints(a[i], b[j]);
    			if (Dist < MinDist)
    			{
    				Line.P1 = a[i];
    				Line.P2 = b[j];
    				MinDist = Dist;
    			}
    		}
    	}
    }
    double Distance_BtwnPoints(Point p, Point q)
    {
    	int X_Diff = p.X - q.X;
    	int Y_Diff = p.Y - q.Y;
    	return Math.Sqrt((X_Diff * X_Diff) + (Y_Diff * Y_Diff));
    }
