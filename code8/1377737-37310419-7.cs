    public bool InitLib()
    {	
    	return MessageLoopApartment.Apartament.Run(() =>
    	{
    		 ca = new CoreAPI();
    		 bool initialized = ca.Init();
    	}, CancellationToken.None).Result;
    }
