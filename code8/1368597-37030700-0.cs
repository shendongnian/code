    foreach (PropertyInfo p in this.GetType().GetProperties().Where(p => p.PropertyType == typeof(ThermodynamicProperty)))
    {
        ThermodynamicProperty propertyObject = (ThermodynamicProperty)p.GetValue(this);
        if (!propertyObject.IsBasis)
        {
            propertyObject.BasisChanged = true;
         }
    }
