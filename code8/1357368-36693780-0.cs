    EntityCollection businessUnits = _orgService.RetrieveMultiple(new FetchExpression(fetchBU));
    if (businessUnits.Entities.Count > 0)
    {
        Entity equipment = new Entity("equipment");
        equipment["name"] = "test";
        equipment["businessunitid"] = new EntityReference("businessunit", businessUnits.Entities[0].Id);
        _orgService.Create(equipment);
        Console.WriteLine("Facility successfully created");
    }
