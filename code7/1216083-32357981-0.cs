    [HttpPost]
    public ActionResult MyActionMethod(FormCollection form)
    {
        if (ModelState.IsValid)
        {
            const string name = "LongArray";
    
            IList<long> longArray = form[name] != null
                ? form[name].Split(new[] { ',' }, 
                    StringSplitOptions.RemoveEmptyEntries).Select(x => Convert.ToInt64(x)).ToList()
                : new List<long>();
            
            // Some other fields
            string someInputValue = form["SomeInput"];
        }
        ...
    }
