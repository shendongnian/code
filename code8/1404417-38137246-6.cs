     var hubConnection = new HubConnection(url,...); 
     ... ; /*defining proxies and handlers*/
     hubConnection.Start().ContinueWith( t=> {
                                               /* code to run if connection has been made successfully */
                                             },TaskContinuationOptions.OnlyOnRanToCompletion );
