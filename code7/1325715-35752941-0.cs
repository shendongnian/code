    var entityId = 13;
    ...
    // This is "false"
    var hasEntityWithValue = db.MyEntity.Any(p => p.Id == entityId && p.MyProperty1 != null);
    // The "myEntity" is null
    var myEntity = db.MyEntity.FirstOrDefault(p => p.Id == entityId && p.MyProperty1 != null);
