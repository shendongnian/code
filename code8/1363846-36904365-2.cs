    [ResponseType(typeof(bool))]
    public async Task<IHttpActionResult> Send() {
        await dosomething();
        return Ok(true);
    }
