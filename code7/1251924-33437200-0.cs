    void Main()
    {
    	var str="3.0E-4";
    	float d;
    	if (float.TryParse(str, out d))
    	{
    		Console.WriteLine("d = " + d.ToString());
    	}
    	else
    	{
    		Console.WriteLine("Not a valid decimal!");
    	}
    }
