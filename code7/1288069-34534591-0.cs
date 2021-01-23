    public static class Session
    {
          public static string UserName
          {
               get { return (JsonWhereClause)HttpContext.Current.Session["UserName"]; }
               set { HttpContext.Current.Session["UserName"] = value; }
          }
    }
