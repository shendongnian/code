    HttpClient.PostAsJsonAsync("http://Server/WebService/Controller/ServiceMethod?number=" + number + "&name" + name, Tuple.Create(args1, args2, args3, args4));
    
    [HttpPost]
    [Route("ServiceMethod")]
    [ResponseType(typeof(void))]
    public IHttpActionResult ServiceMethod(int number, string name, Tuple<Class1, Class2, Class3, Class4> args)
    {
    	Class1 c1 = (Class1)args.Item1;
    	Class2 c2 = (Class2)args.Item2;
    	Class3 c3 = (Class3)args.Item3;
    	Class4 c4 = (Class4)args.Item4;
    	/* do your actions */
        return Ok();
    }
