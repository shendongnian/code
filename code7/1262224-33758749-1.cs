     public ActionResult MyMethod(IDictionary<string, string> model)
     {
         var parameters = new List<Parameter>();
         parameters.Add(new parameter { name = "AString", value = new List<string> { model.AString }});
         parameters.Add(new parameter { name = "BString", value = new List<string> { model.BString }});
