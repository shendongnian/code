    PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(Derived));
    for (int i = 0; i < properties.Count; i++)
    {
         Console.WriteLine(properties[i].Name);
    }
