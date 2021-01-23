     object[] browsable;
    Type type = typeof(xxx);
    FieldInfo[] fieldInfos = type.GetFields();
    foreach (FieldInfo fieldInfo in fieldInfos)
    {
        browsable = fieldInfo.GetCustomAttributes(typeof(BrowsableAttribute), false);
        if (browsable.Length == 1)
        {
            
            System.ComponentModel.PropertyDescriptorCollection pdc = System.ComponentModel.TypeDescriptor.GetProperties(fieldInfo);
            //Get property descriptor for current property
            System.ComponentModel.PropertyDescriptor descriptor = pdc[24];// custom attribute
            BrowsableAttribute attrib =
          (BrowsableAttribute)descriptor.Attributes[typeof(BrowsableAttribute)]; 
            FieldInfo isReadOnly =
             attrib.GetType().GetField("browsable", BindingFlags.NonPublic | BindingFlags.Instance);
            isReadOnly.SetValue(attrib, true);
        }
    }
