    [HttpPost]
    public void Whatever(Threat model)
    {
        var connectedModel = context.Threats.FirstOrDefault(x => x.ID == model.ID);
        connectedModel.SomeProperty = model.SomeProperty; //or use AutoMapper
        context.SaveChanges();   
    }
