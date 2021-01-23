    private void PlaceValues(ref MyClass c, int SetMe)
    {
        PropertyDescriptorCollection col = TypeDescriptor.GetProperties(c);
        foreach (PropertyDescriptor prop in col)
        {
            if (prop.DisplayName != "Property1" & prop.DisplayName != "Property2")
            {
                prop.SetValue(c, SetMe);
            }
        }
    }
