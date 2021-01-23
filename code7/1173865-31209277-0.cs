            private bool jobIsComplete;
    
            private void Run()
            {
                 while (true)
                {
                     jobIsComplete = false;
                     //get the message
                     var cloudMessage = await queue.GetMessageAsync();
                 
                     if (cloudMessage != null)
                            //run the task to keep the message until end of the job and worker role stopping for an update for example 
                           var keepHiddenMessageTask = KeepHiddenMessageAsync(cloudMessage);
                           
                            //
                            // process my job (few hours)
                            //
      
                          jobIsComplete = true;
                          await keepHiddenMessageTask;
                          await _queue.DeleteMessageAsync(cloudMessage);
                     else
                           await Task.Delay(1000 * 5);
                }
            }
           
            private async Task KeepHiddenMessageAsync(CloudQueueMessage iCloudQueueMessage)
            {
                while (true)
                {
                    //Update message and hidding during 5 new minutes
                    await _queue.UpdateMessageAsync(iCloudQueueMessage, TimeSpan.FromMinutes(5), MessageUpdateFields.Visibility);
    
                    //Wait 4 minutes
                    for (int i = 0; i < 60 * 4; i++)
                    {
                        if (JobIsComplete)
                            return;
                        else
                            await Task.Delay(1000);
                    }
                }
            }
