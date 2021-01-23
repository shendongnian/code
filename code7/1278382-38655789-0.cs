    int PressedCoordinate;
    int ReleasedCoordinate;
    
    private void Mouse_Down(object sender, MouseEventArgs e)
    {
    	if (e.Button == MouseButtons.Left)
    	{
    		int PressedCoordinate = e.X;
    		//in this part, calculate the DateTime based on the scale of pixel vs datetime
    	}
    }
    
    private void Mouse_Up(object sender, MouseEventArgs e)
    {
    	if (e.Button == MouseButtons.Left)
    	{
    		int ReleasedCoordinate = e.X;
    		//in this part, calculate the DateTime based on the scale of pixel vs datetime
    		//calculate the range and do the zoom-in logic
    	}
    }
