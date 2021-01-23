    public void SetID(int Id)
    {
    	if (Id <= 0)
    	{
    		throw new Exception("It is not a Valid ID");
    	}
    	_ID = Id;
    }
