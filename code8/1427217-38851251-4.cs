    [ResponseType(typeof(string))]
    [Route("MyMethodA")]
    public Task<IHttpActionResult> MyMethodA(int arg1) {
        var result = CallWF<string>(
        () => {
            return repositoryA.itsMethodA(arg1);
        });
    
        return Task.FromResult(result);
    }
