    public bool AreEqual(IEnumerable<KeyValuePair<PropertyInfo, PropertyInfo>> properties,
        DbModel1.Product left,
        DbModel2.Product right)
    {
        foreach(var property in properties)
        {
            var leftValue = property.SourceProperty.GetValue(left, null);
            var rightValue = property.DestinationProperty.GetValue(right, null);
            if(!leftValue.Equals(rightValue))
                return false;
        }
        return true;
    }
