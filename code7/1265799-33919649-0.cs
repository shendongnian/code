    private static void BuildWhere(StringBuilder sb, IEnumerable<PropertyInfo> idProps, object sourceEntity, object whereConditions = null)
    var propertyInfos = idProps.ToArray();
    string param = "";
    
    ...
    
    try
    {
        // use the 'is null' operator if value of parameter null, else use '=' operator
        param = (whereConditions.GetType().GetProperty(propertyToUse.Name).GetValue(whereConditions, null) != null ? "{0} = @{1}" : "{0} is null");
    }
    catch (Exception err)
    {
        param = "{0} = @{1}";
    }                
    
    sb.AppendFormat(param, GetColumnName(propertyToUse), propertyInfos.ElementAt(i).Name);
