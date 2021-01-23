    [HttpPost]
    public ActionResult createXML(FormCollection collection)
    {
         // Build your WebForm object
         WebFormXML wfx = new WebFormXML();
         // Get your suppressed items
         var suppressions = collection["suppressions"].Split(',');
         // Add each of them to your object
         wfx.Suppressions.AddRange(suppressions);
         
         // Other code here
    }
        
