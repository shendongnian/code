    [HttpPost]
    public ActionResult MyView(MyModel myModelResponse) 
    {
        var myVar = myModelResponse.UID;
        var myVar2 = myModelRepsonse.name;
        ObjectMethod myMethod = new ObjectMethod // calls new object 
        var myObject = myMethod.ObjectMethodObject(myVar, myVar2);
        
        string JsonObject = JsonConvert.SerializeObject(myObject);
        
        return View(JsonObject);
    }
