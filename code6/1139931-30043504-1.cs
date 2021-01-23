    void Main()
    {
    	CopyFrom<Customer>("<source connection string>");
    }
    
    void CopyFrom<TTable> (string sourceCxString) where TTable : class
    {
    	// Create another typed data context for the source. Note that it must have compatible schema:
    	using (var sourceContext = new TypedDataContext (sourceCxString) { ObjectTrackingEnabled = false })
    	{
    		// Delete the rows currently in our table:
    		ExecuteCommand ("delete " + Mapping.GetTable (typeof (TTable)).TableName);
    		
    		// Insert the rows from the source table into the target table and submit changes:
    		GetTable<TTable>().InsertAllOnSubmit (sourceContext.GetTable<TTable>());
    		SubmitChanges();
    	}
    }
