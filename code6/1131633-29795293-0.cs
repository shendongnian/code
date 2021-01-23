    public ExpandoObject go( IEnumerable<IDictionary<string,object>> lst)
    {
     
     return lst.Aggregate(new ExpandoObject(),
                               (aTotal,n) => {
                                    (aTotal    as IDictionary<string, object>).Add(n["Key"].ToString(), n["Value"] is object[] ? go(  ((object[])n["Value"]).Cast<IDictionary<string,Object>>())  :n["Value"] );
                                    return aTotal;
                               });
     
    }
