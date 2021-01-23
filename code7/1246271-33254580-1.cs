    A aObj = aService.GetAById(id);
    B bObj = bService.GetBByName(name);
    D dObj = new D()
    {
        Title = "MyTitle",
        AFieldId = aObj.Id,
        BFieldId = bObj.Id
    };
    dService.Update(dObj);
