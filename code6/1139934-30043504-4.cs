    void Main()
    {
        SimpleSelect("<your conn string>");
    }
    
    void SimpleSelect (string sourceCxString)
    {
        // Create another typed data context for the source. Note that it must have compatible schema:
        using (var sourceContext = new TypedDataContext (sourceCxString) { ObjectTrackingEnabled = false })
        {
            sourceContext.Assignee.OrderByDescending(a => a.CreateTimeStamp).Take(10).Dump();
    		Assignee.OrderByDescending(a => a.CreateTimeStamp).Take(10).Dump();
        }
    }
