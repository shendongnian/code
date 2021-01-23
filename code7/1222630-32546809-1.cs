    public void ConsolidateLists()
    {
    	while (training.Count > 0 || testing.Count > 0)
    		Controller.GrabFromList(output, training.Count > 0 && (testing.Count == 0 ^ training[0].Index < testing[0].Index) ? training : testing);
    }
    
