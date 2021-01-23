    [HttpGet]
    public HttpResponseMessage GetResultFromLongRunningMethod()
    {
        using (PerformanceWatcher watcher = new PerformanceWatcher(40))
        {
            try
            {
                // long-running operation
            } catch (TimeLimitExceededException e)
            {
                return this.Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Time limit exceeded");
            }
        }
        return this.Request.CreateResponse(HttpStatusCode.OK, "everything ok");
    }
