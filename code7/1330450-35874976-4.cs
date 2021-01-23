    void CreateMe(Dictionary<PropertyNames, string> propertyBag)
    {
        foreach (var propertyPair in propertyBag)
        {
            string propertyName = propertyPair.Key.GetDescription();
            string propertyValue = propertyPair.Value;
        }
    } 
