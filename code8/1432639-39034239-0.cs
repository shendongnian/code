    var query = (Expression<Func<Person, bool>>)(model => model.FirstName == "test2");
    var remoteExpression = query.ToRemoteLinqExpression();
        
    var request = new Request<Person>
    {
           Items = new List<Person>()
           {
              new Person() { FirstName = "test", Id = 1 },
               new Person() { FirstName = "test2", Id = 2 }
           },
          Expression = remoteExpression
    };
    var serializerSettings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto };
    string jsonString = JsonConvert.SerializeObject(request, serializerSettings);
    var result = JsonConvert.DeserializeObject<Request<Person>>(jsonString, serializerSettings);
    var expresion = result.Expression.ToLinqExpression<Person, bool>();
    var filtered = request.Items.Where(expresion.Compile()).ToList();
