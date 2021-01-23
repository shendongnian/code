    protected Task<IHttpActionResult> CallWFAsync<T>(Func<T> action) {
        IHttpActionResult result = null;
        try
        {
            result = Ok(action.Invoke());
        } catch (Exception e1) {
            result = BadRequest(GetMyExceptionMessage(e1));
        }
        return Task.FromResult(result);
    }
