    Get["/api/docs/{category}"] = _ =>
    {
       var filterValue = _.category;
       //Search the DB for one record where the category property matches the filterValue
       var item = database.GetCollection("docs").FindOne(Query.EQ("category", filterValue))
       var json = item.ToJson();
      
       var jsonBytes = Encoding.UTF8.GetBytes(json );
       return new Response
       {
          ContentType = "application/json",
          Contents = s => s.Write(jsonBytes, 0, jsonBytes.Length)
       };
    };
