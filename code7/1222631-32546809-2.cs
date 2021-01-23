    public void ConsolidateLists()
    {
    	while (training.Count > 0 || testing.Count > 0)
    	{
    		if (training.Count == 0 || (testing.Count > 0 && training[0].Index >= testing[0].Index))
    		{
    			Controller.GrabFromList(output, testing);
    		}
    		else
    		{
    			Controller.GrabFromList(output, training);
    		}
    	}
    }
    
