    var entities = context.Business.ToList();
    foreach(var baseEntity in entities)
    {
        // some common logic for base entity type
        if (baseEntity is BusinessType1)
        {
            var concreteEntity = (BusinessType1)baseEntity;
            // some logic for entity of BusinessType1
        }
    }
