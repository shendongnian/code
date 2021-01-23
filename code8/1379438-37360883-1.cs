    public CRadnaMesta Radnomesto
    {
    	get
    	{
    		return radnomesto;
    	}
    	set
    	{
    		if ( value.ID == 0 )
    			throw new Exception("Morate uneti radno mesto.");
    		radnomesto = value;
    	}
    }
