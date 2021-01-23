    IDictionary<JsonProperty, object> propertyValues = 
        ResolvePropertyAndCreatorValues(contract, containerProperty, reader, objectType, out extensionData);
    object[] creatorParameterValues = new object[contract.CreatorParameters.Count];
    IDictionary<JsonProperty, object> remainingPropertyValues = new Dictionary<JsonProperty, object>();
    foreach (KeyValuePair<JsonProperty, object> propertyValue in propertyValues)
    {
        JsonProperty property = propertyValue.Key;
        JsonProperty matchingCreatorParameter;
        if (contract.CreatorParameters.Contains(property))
        {
            matchingCreatorParameter = property;
        }
        else
        {
            // check to see if a parameter with the same name as the underlying property name exists and match to that
            matchingCreatorParameter = contract.CreatorParameters.ForgivingCaseSensitiveFind(p => p.PropertyName, property.UnderlyingName);
        }
        if (matchingCreatorParameter != null)
        {
            int i = contract.CreatorParameters.IndexOf(matchingCreatorParameter);
            creatorParameterValues[i] = propertyValue.Value;
        }
        else
        {
            remainingPropertyValues.Add(propertyValue);
        }
        ...
    } 
    ...
    object createdObject = creator(creatorParameterValues);
    ...
