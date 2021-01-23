    public void StoreWorkData(List<TypeAndvalue> workDataPropertyDetails)
    {
        foreach (var property in workDataPropertyDetails)
        {
            dynamic newValue = Parse(property.dataType, property.Value);
            SomeMethod(newValue);
        }
    }
