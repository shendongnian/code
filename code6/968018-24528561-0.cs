    public static class Extensions
     {
    		public static Task<SqlDataReader> ExecuteReaderAsync(this SqlCommand command, CancellationToken token)
    		{	
    			var tcs = new TaskCompletionSource<SqlDataReader>();
    			
    			// whne the token is cancelled, cancel the command
    			token.Register( () => 
    			{
    				command.Cancel();
    				tcs.SetCanceled();
    			});
    			
    			command.BeginExecuteReader( (r) =>
    			{
    				try
    				{
    					tcs.SetResult(command.EndExecuteReader(r));
    				}
    				catch(Exception ex)
    				{
    					tcs.SetException(ex);
    				}
    			}, null);
    		
    			return tcs.Task;
    		}
     }
