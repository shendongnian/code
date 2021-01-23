    public ActionResult CancelDoc(string[] datakeys)
    { 
        dyamic sourceJson = JsonConvert.DeserializeObject(dataKeys, typeof(object));
        DocObject Doc = new DocObject();
        List<string> Datakeys = sourceJson.ToList();
    
    }
