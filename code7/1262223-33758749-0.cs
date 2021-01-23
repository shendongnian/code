     public ActionResult MyMethod(IDictionary<string, string> model)
     {
         var parameters = new List<Parameter>();
         foreach (var kvp in model)
         {
             parameters.Add(new parameter { name = kvp.Key, value = new List<string> { key.Value }});
         }
