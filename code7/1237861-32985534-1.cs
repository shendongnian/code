    private bool EnsureCapacity(int value)
    {
	if (value < 0)
	{
		throw new IOException(Environment.GetResourceString("IO.IO_StreamTooLong"));
	}
	if (value > this._capacity)
	{
		int num = value;
		if (num < 256)
		{
			num = 256;
		}
		if (num < this._capacity * 2)
		{
			num = this._capacity * 2;
		}
		if (this._capacity * 2 > 2147483591)
		{
			num = ((value > 2147483591) ? value : 2147483591);
		}
		this.Capacity = num;
		return true;
	    }
	  return false;
    }
