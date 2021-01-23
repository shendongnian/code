    public static IDictionary<string,string> MergeRouteQueryValues (this Controller c) {
      var d = new Dictionary<string,string>() {
        {"controller",c.ControllerName()},
        {"action",c.ActionName()}
      };
      foreach (string key in c.Request.QueryString.Keys) { 
        d.Add(key,c.Request.QueryString[key]);
      }
      return d;
    }
