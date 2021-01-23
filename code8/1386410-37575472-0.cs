    class MyWrapper
    {
    	private readonly char[,] data;
    	public MyWrapper(char[,] data)
    	{
    		this.data=data;
    	}
    	private bool InRange(int x, int y)
    	{
    		return x >= 0 && y >= 0 && x < data.GetLength(0) && y < data.GetLength(1);
    	}
    	public char this[int x, int y]
        {
    		get
    		{ 
    			return InRange(x,y) ? data[x,y] : ' ';
    		}
    		set
    		{
    			if(InRange(x,y)) data[x,y] = value;
    		}
    	}
    }
