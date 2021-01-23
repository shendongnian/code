    // Assign our binding model to a new model
    var collection = new Web.Models.Collection()
    {
        PlannedCollectionDate = model.PlannedCollectionDate.ToZoneTime().Date
    };
