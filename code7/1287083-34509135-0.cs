    var property = constraint.GetType().GetProperty("Parameter"); 
    if (property != null)
    {
        var parameter = property.GetValue(constraint);
        if (parameter != null)
        {
            var parameterName = parameter.GetType().GetProperty("Name").GetValue(parameter).ToString();
            if (parameterName == "Length")
            {
                property.SetValue(constraint, myLengthParameter);
            }
        }        
    }
