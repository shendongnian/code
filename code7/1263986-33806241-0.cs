    class MyObject : IDisposable
    {
        //indicates if dispose has already been called
        //private bool _disposed = false;
    
        //Finalize method for the object, will call Dispose for us
        //to clean up the resources if the user has not called it
        ~MyObject()
        {
            //Indicate that the GC called Dispose, not the user
            Dispose(false);
        }
    
        //This is the public method, it will HOPEFULLY but
        //not always be called by users of the class
        public void Dispose()
        {
            //indicate this was NOT called by the Garbage collector
            Dispose(true);
    
            //Now we have disposed of all our resources, the GC does not
            //need to do anything, stop the finalizer being called
            GC.SupressFinalize(this);
        }
    
        private void Dispose(bool disposing)
        {
            //Check to see if we have already disposed the object
            //this is necessary because we should be able to call
            //Dispose multiple times without throwing an error
            if (!disposed)
            {
                if (disposing)
                {
                    //clean up managed resources
                    components.Dispose();
                }
    
                //clear up any unmanaged resources - this is safe to
                //put outside the disposing check because if the user
                //called dispose we want to also clean up unmanaged
                //resources, if the GC called Dispose then we only
                //want to clean up managed resources
            }
        }
    }
