    private static readonly Task _completedTask = Task.FromResult(false);
    public override async Task<IHttpActionResult> Delete(int id)
    {
        await _completedTask;
        return ResponseMessage(Request.CreateResponse(HttpStatusCode.MethodNotAllowed, new NotSupportedException()));
    }
