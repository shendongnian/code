    Dictionary<string,ProgressBar> ProgressBars = new Dictionary<string,ProgressBar>();
    
    void Main()
    {
        ProgressBars["MyBar1"] = new ProgressBar();
    
    	//... later on
    	ProgressBar progressBar = ProgressBars["MyBar1"];
    	progressBar.PerformStep();
    	progressBar.Step = 77;
    	
    	progressBar.Step.Dump();
    
    }
