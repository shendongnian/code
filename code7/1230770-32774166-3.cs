    void DoWork() // handles loading of an array
    { 
        // load array here. cbo is disabled 
        myArrayOfValues = <whatever you get from DB>
        foreach var item in myArrayOfValues 
        {
            // here call `worker.Progress` and pass your item in argument
        }
    }
    void OnWorkComleted(....) 
    { 
       // Set your combo as disabled initially, so people can't click while it is loading
       
        cbo.Enabled = true;
        
    }
 
    void OnWorkerProgress(....) 
    { 
        // Add items one by one
        cbo.Items.Add(myValue);
        
    }
    
