    [Route("foo/{Id}")]
    [ResponseType(typeof(ObjectA))]
    public HttpResponseMessage Get(int Id) //Return objectA
    [Route("foo/Search")]
    [ResponseType(typeof(ObjectB))]
    public HttpResponseMessage Get(string criteria) //Return objectB
    [Route("foo/Anything")]
    [ResponseType(typeof(ObjectC))]
    public HttpResponseMessage Get(anything bar) //Return objectC
