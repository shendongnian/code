           var saveTask = new Task<ReturnedObject>(() =>  //if you don't need values in order to update the UI you can use Task not Task<T>
                        {
                          //do your save action and return something if you want 
            			});
                            
                        //start thread
                        saveTask.Start();
            
                        saveTask.ContinueWith(previousTask =>
                        {//after the first thread is completed, this point will be hit
            			
            				//loading action here
            				
            				//UI region if needed
                                Application.Current.Dispatcher.BeginInvoke((ThreadStart)delegate
                                {
                                  //update UI
                                }, DispatcherPriority.Render);               
            
                        }, TaskScheduler
        
        .FromCurrentSynchronizationContext());
