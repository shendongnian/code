    public string LinkBuilder(Dictionary<string, string> parameters)
    {
         var url = String.Empty;
         foreach(var parameter in parameters)
             if(!string.IsNullOrEmpty(parameter.Value))
                   url += String.Format("&{0}={1}", parameter.Key, parameter.Value);
         return url;
    }
