    public static int ReorderInt32Digits(int v)
    {
    	var nums = Math.Abs(v).ToString().ToCharArray();
    	Array.Sort(nums);
    	bool neg = (v < 0);
    	if(!neg)
    	{
    		Array.Reverse(nums);	
    	}
    	return int.Parse(new string(nums)) * (neg ? -1 : 1);
    }
