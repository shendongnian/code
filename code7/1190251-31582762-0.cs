    bool wall1 = false;
    bool wall2 = false;
    
    void Update()
    {
    	if( wall1 && wall2 )
    	{
    		Die();
    	}
    }
    
    void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Crush")
        {
            wall1 = true;
        }
        else if(other.transform.tag == "Crush1")
        {
        	wall2 = true;
        }
    }
    
    
    void OnCollisionExit(Collision other)
    {
        if (other.transform.tag == "Crush")
        {
            wall1 = false;
        }
        else if(other.transform.tag == "Crush1")
        {
        	wall2 = false;
        }
    }
