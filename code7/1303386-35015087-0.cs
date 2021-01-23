    client = new GraphClient(new Uri(connString), dbuser, dbpass);
    client.Connect();
    var results = (Result)client.Cypher.Match("(a:Student)")
                                       .With("keys(a) as k")
                                       .Unwind("k as x")
                                       .ReturnDistinct<Result>("x")
                                       .Results.ToList()
