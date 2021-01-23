    public void Draw(Control ctrl)
    {
    	ctrl.Width = 100;
    	ctrl.Height = 200;
    	
    	using(Graphic g = ctrl.CreateGraphics()) 
    	{
    		//...
    		//Draw something
    		//...
    	}
    }
