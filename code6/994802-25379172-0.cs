            AddProgressDelegate addProgress = new AddProgressDelegate(AddProgress);
            
            try
            {
               
                IAsyncResult result = addProgress.BeginInvoke(session, progress, null, null);
               result.AsyncWaitHandle.WaitOne(timeoutValue);
                
                
            }
            catch (Exception ex)
            {
                
            }
            finally
            {
                addProgress = null;
               
            }
            
            
        }
