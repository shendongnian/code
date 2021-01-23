    public IQueryable<Row> Action()
    {
      var result = db.table.Where(e => true);
      foreach(var parameter in HttpUtility.ParseQueryString(ActionContext.Request.RequestUri.Query).ToKeyValuePairs())
      {
        switch(parameter.Key)
        {
          case "a":
            result = result.Where(e => e.a == parameter.Value);
            break;
          case "b":
            result = result.Where(e => e.a == parameter.Value);
            break;
          ...
        }   
    
      }
      return result;
    }
