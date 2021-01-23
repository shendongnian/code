    public PropertyDescriptorCollection GetProperties(Attribute[] attributes)
    {
        PropertyDescriptorCollection propertyDescriptorCollection = TypeDescriptor.GetProperties(this);
        var propertyDescriptors = new List<PropertyDescriptor>();
        for (int i = 0; i < propertyDescriptorCollection.Count; i++)
        {
            propertyDescriptors.Add(propertyDescriptorCollection[i]);
        }
        PropertyDescriptorCollection class2PropertyDescriptorCollection = TypeDescriptor.GetProperties(class2);
        for (int i = 0; i < class2PropertyDescriptorCollection.Count; i++)
        {
            propertyDescriptors.Add(class2PropertyDescriptorCollection[i]);
        }
        return new PropertyDescriptorCollection(propertyDescriptors.ToArray());
    }
