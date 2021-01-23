    foreach (var property in entityEntry.OriginalValues.Properties)
    {
        if (!object.Equals(entityEntry.OriginalValues.GetValue<object>(property), 
            entityEntry.CurrentValues.GetValue<object>(property)))
        {
            result.Add(
                new AuditLog()
                {
                    UserId = userId,
                    EventDate = changeTime,
                    EventType = "M",
                    TableName = tableName,
                    RecordId = entityEntry.OriginalValues.GetValue<object>(keyName).ToString(),
                    ColumnName = property.Name,
                    OriginalValue =
                        entityEntry.OriginalValues.GetValue<object>(property) == null
                        ? null
                        : entityEntry.OriginalValues.GetValue<object>(property).ToString(),
                    NewValue = 
                        entityEntry.CurrentValues.GetValue<object>(property) == null
                        ? null
                        : entityEntry.CurrentValues.GetValue<object>(property).ToString()
            });
        }
    }
