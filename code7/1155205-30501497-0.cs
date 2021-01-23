    public override async Task<IHttpActionResult> Delete(int id)
    {
        await Task.FromResult(false);
        return ResponseMessage(Request.CreateResponse(HttpStatusCode.MethodNotAllowed, new NotSupportedException()));
    }
