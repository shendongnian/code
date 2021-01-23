    public bool IsMatch(Color colorA, Color colorB)
    {
    	return IsMatch(colorA.Red, colorB.Red)
    		&& IsMatch(colorA.Green, colorB.Green)
    		&& IsMatch(colorA.Blue, colorB.Blue);
    }
    
    public bool IsMatch(double colorA, double colorB)
    {
    	var difference = colorA - colorB;
    	return -5 < difference
    		|| difference < 5;
    }
