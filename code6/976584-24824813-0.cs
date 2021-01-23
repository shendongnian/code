    public async Task NotifyObservers()
    {
    	List<Task> notifyTasks = new List<Task>();
    	
    	foreach (var observer in registeredObservers)
    	{
    		if (observer != null)
    		{
    			notifyTasks.Add(observer.OnMessageRecieveEvent(new ObserverEvent(item)));
    		}
    	}
    	
    	// asynchronously wait for all the tasks to complete
    	await Task.WhenAll(notifyTasks);	
    }
     
     public async Task OnMessageRecieveEvent(ObserverEvent e)
     {
        await SendSignal(e.message.payload);
     }
    
      private Task SendSignal(Byte[] signal)
      {
            if (!state.WorkSocket.Connected)
            {
    			CloseConnection();
    			return Task.FromResult<object>(null);
    		}
    		else
    		{
    			var tcs = new TaskCompletionSource<object>();
    			
                try
                {
                    // Sends async
                    state.WorkSocket.BeginSend(signal, 0, signal.Length, 0, (ar) =>
    				{
    					try
    					{
    						var socket = (Scoket)ar.AsyncState;
    						tcs.SetResult(socket.EndSend(ar));
    					}
    					catch(Exception ex)
    					{
    						tcs.SetException(ex);
    					}
    				
    				}
    				, state.WorkSocket);
                }
                catch (Exception e)
                {                    
                    log.Error("Transmission Failier for ip: " + state.WorkSocket.AddressFamily , e);
                    tcs.SetException(e);
                }
            }
           
    	   return tcs.Task;
        }
