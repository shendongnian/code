    public void PullData(string sortExp, string sortDir)
    {
        // build your query string
        // ...
    
        // Now create a hash of that query string
        string cacheKey = HashHelper(query);
    
        DataSet ds = null;
    
        // check cache if key exists
        if(Cache[cacheKey] != null)
        {
             // read dataset from cache
             ds = (DataSet)Cache[cacheKey];
        }
        else
        {
            // perform sql command and fill your dataset
            // ....
            // save dataset to cache for 30 minutes or whatever you like
            Cache.Insert(cacheKey, ds, null, DateTime.Now.AddMinutes(30), TimeSpan.Zero);
        }
    
        // Get DataView based on sort options
        DataView myDataView = new DataView();
        myDataView = ds.Tables[0].DefaultView;
    
        if (sortExp != string.Empty)
        {
            myDataView.Sort = string.Format("{0} {1}", sortExp, sortDir);
        }
    
        yourTasksGV.DataSource = myDataView;
        yourTasksGV.DataBind();
    
        TasksUpdatePanel.Update();
    
        // keep calm and carry on
    }
