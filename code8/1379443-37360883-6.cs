    public CRadnaMesta Radnomesto
    {
    	get
    	{
    		return radnomesto;
    	}
    	set
    	{
    		if ( radnomesto.ID == 0 )
    			throw new Exception("Morate uneti radno mesto.");
    		radnomesto = value;
    	}
    }
