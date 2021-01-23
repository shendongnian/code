    public string LinkBuilder(Dictionary<string, string> parameters)
    {
         var url = String.Empty;
         foreach(var parameter in parameters)
             url += AppendQueryString(parameter.Key, parameter.Value);
         return url;
    }
