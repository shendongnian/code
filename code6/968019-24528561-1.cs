     public static SqlDataReader Execute(SqlCommand command)
     {
         SqlDataReader r = null;
         var cts = new CancellationTokenSource();
         var cToken = cts.Token;
         Task<SqlDataReader> executeQuery = command.ExecuteReaderAsync(cToken).
    													.ContinueWith( t =>
    													{
    														if(t.IsCompleted)
    														{
    															r = t.Result;		
    														}		
    													}, TaskScheduler.Default);
    	 
         //create a form with execute task and action for cancel task if user click on button
         LoadingFrm _lFrm = new LoadingFrm(executeQuery, () => { cts.Cancel(); });
    	 
    	 // Assuming this is blocking and that the executeQuery will have finished by then, otheriwse
    	 // may need to call executeQuery.Wait().
         _lFrm.ShowDialog(); 	 					    
    	
         return r;
     }
	  
