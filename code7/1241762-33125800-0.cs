    Rectangle myRectangle = new Rectangle();
    myRectangle += myRectangle_MouseLeftButtonDown;
    
    void myRectangle_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
    	myRectangle.MouseMove += origin_MouseMove;
    }
    
    void myRectangle_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
    {
    	Point p = new Point()
    	{	
    		// Just round the coordinates
    		X = Math.Round(e.GetPosition(canvas).X, 0, MidpointRounding.AwayFromZero),	
    		Y = Math.Round(e.GetPosition(canvas).Y, 0, MidpointRounding.AwayFromZero),
    	};
    
    	Canvas.SetTop(myRectangle, p.Y);
    	Canvas.SetLeft(myRectangle, p.X);
    
    	myRectangle.MouseLeftButtonUp += myRectangle_MouseLeftButtonUp;
    }
    
    void myRectangle_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
    	myRectangle.MouseMove -= origin_MouseMove;
    	myRectangle.MouseLeftButtonUp -= origin_MouseLeftButtonUp;
    }
