    [HttpGet]
    public HttpResponseMessage GetResultFromLongRunningMethod()
    {
        using (PerformanceWatcher watcher = new PerformanceWatcher(10))
        {
            try
            {
                // begin long-running operation
                for (int i = 0; i < 20; i++) 
                {
                    if (watcher.TimeLimitExceeded) 
                    {
                        throw new TimeLimitExceededException();
                    }
                    Thread.Sleep(1000);
                }
                // end long-running operation
            } catch (TimeLimitExceededException e)
            {
                return this.Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Time limit exceeded");
            }
        }
        return this.Request.CreateResponse(HttpStatusCode.OK, "everything ok");
    }
