    foreach (var name in propertyNames)
    {
        var value = entity.GetType().GetProperty(name).GetValue(entity, null);
        attachedEntity.GetType().GetProperty(name).SetValue(attachedEntity, value);
    }
