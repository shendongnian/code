    public ActionResult CancelDoc(string[] datakeys)
    { 
        dynamic sourceJson = JsonConvert.DeserializeObject(dataKeys, typeof(object));
        DocObject Doc = new DocObject();
        List<string> Datakeys = sourceJson.ToList();
    
    }
