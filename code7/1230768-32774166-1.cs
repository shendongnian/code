    void DoWork() // handles loading of an array
    { 
        // load array here. cbo is disabled 
        myArrayOfValues = <whatever you get from DB>
    }
    void OnWorkComleted() // set your combo box
    { 
        // Assign your data source here
        // Set your combo as disabled initially, so people can't click while it is loading
        cbo.BeginUpdate(); // begin update used in list controls to stop fickering when items added
        cbo.DataSource = myArrayOfValues;
        cbo.EndUpdate();
        cbo.Enabled = true;
        
    }
     
