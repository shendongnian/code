    foreach (var prop in props) // For each of type's properties
    {
        if (prop.GetCustomAttributes(typeof(Mappable)).Any())
        {
            mapSwitch = 1;
        }
    }
    
    if (isLevelMatch(isContinueToGetData, mapSwitch, props))
    {
        if (model.GetType().GetProperty(prop.Name).GetValue(obj) != null)
        {
            comModel.FieldValueLet(prop.Name, model.GetType().GetProperty(prop.Name).GetValue(obj));
        }
        else
        {
            comModel.FieldValueLet(prop.Name, DBNull.Value);
        }
    }
