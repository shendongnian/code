    [ResponseType(typeof(string))]
    [Route("MyMethodA")]
    public async Task<IHttpActionResult> MyMethodA(int arg1)
    {
        return await CallWFAsync<string>(
        () => {
            return repositoryA.itsMethodA(arg1);
        });
    }
