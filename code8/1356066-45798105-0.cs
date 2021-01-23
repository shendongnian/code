    if (!call.IsConditional)
    			{
    				lock (calls)
    				{
    					// if it's not a conditional call, we do
    					// all the override setups.
    					// TODO maybe add the conditionals to other
    					// record like calls to be user friendly and display
    					// somethig like: non of this calls were performed.
    					if (calls.ContainsKey(key))
    					{
    						// Remove previous from ordered calls
    						InterceptionContext.RemoveOrderedCall(calls[key]);
    					}
    
    					calls[key] = call;
    }
