    public static async Task<bool> TryToAsync( Action action, int timeoutInSeconds )
    		{
    			var timeout = DateTime.Now.AddSeconds( timeoutInSeconds );
    			while ( DateTime.Now < timeout )
    			{
    				try
    				{
    					action();
    					return true;
    				}
    				catch ( Exception )
    				{
    					await Task.Delay( 200 );
    				}
    			}
    
    			return false;
    		}
