    public override Task<IHttpActionResult> Delete(int id)
    {
        return Task.FromResult<IHttpActionResult>(
                    ResponseMessage(Request.CreateResponse(
                                            HttpStatusCode.MethodNotAllowed,
                                            new NotSupportedException())));
    }
