    public bool HasPropertyChanged(string property, object newValue) 
    {
        PropertyInfo propertyInfo = Entity.GetType().GetProperty(property);
        return !object.Equals(newValue,propertyInfo.GetValue(Entity, null));
    }
