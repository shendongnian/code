    class Pixel : IComparable<Pixel>
    {
     	public int X { get; set; }
    
    	int IComparable<Pixel>.CompareTo(Pixel other)
    	{
    		if (other.X > this.X) { return -1; }
    		else if (other.X == this.X) { return 0; }
    		else {return 1; }
    	}
    }
