    public void InitLib()
    {	
    	MessageLoopApartment.Apartament.Run(() =>
    	{
    		 ca = new CoreAPI();
    		 ca.Init();
    	}, CancellationToken.None).Wait();
    }
