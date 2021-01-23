    void LargerProcess()
    {
        if (condition)
        {
            ReportSomethingHappenedAsync().ContinueWith(task => 
            {
                try
                {
                    task.Wait();
                }
                catch (Exception exception)
                {
                    // handle exception
                }
            })
        }
        
        // do other stuff
    }
