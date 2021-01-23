    private static void SaveIfChanged<T>(Expression<Func<T>> expression, T newValue)
    {
        var expr = (MemberExpression)expression.Body;
        object valuesOfAllFieldsOfObj = null;
        if (expr.Expression != null)
        {
            var obj = (MemberExpression)expr.Expression;
            var fieldsOfObj = (ConstantExpression)obj.Expression;
            valuesOfAllFieldsOfObj = ((FieldInfo)obj.Member).GetValue(fieldsOfObj.Value);
        }
        var propertyInfo = ((PropertyInfo)expr.Member);
        var oldPropertyValue = propertyInfo.GetValue(valuesOfAllFieldsOfObj, null);
        if (oldPropertyValue.Equals(newValue)) return;
            
        var desctiptionAttributes = (DescriptionAttribute[])propertyInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
        Log("{0} changed from {1} to {2}", desctiptionAttributes[0].Description, oldPropertyValue, newValue);
        propertyInfo.SetValue(valuesOfAllFieldsOfObj, newValue, null);
        Save();
    }
