    [Route]
    [HttpGet]
    public IHttpActionResult Search([FromUri(BinderType = typeof(EmptyStringToNullModelBinder))]string q = null)
    {
        return this.ModelState.IsValid
            ? this.Ok(q ?? "null")
            : (IHttpActionResult)this.BadRequest(this.ModelState);
    }
