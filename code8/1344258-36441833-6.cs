    public class ExpandableObservableCollection<T> : ObservableCollection<T>,
                                                     ICustomTypeDescriptor
    {
      PropertyDescriptorCollection ICustomTypeDescriptor.GetProperties()
      {
        // Create a collection object to hold property descriptors
        PropertyDescriptorCollection pds = new PropertyDescriptorCollection(null);
        for (int i = 0; i < Count; i++)
        {
          pds.Add(new ItemPropertyDescriptor<T>(this, i));
        }
        return pds;
      }
      #region Use default TypeDescriptor stuff
      AttributeCollection ICustomTypeDescriptor.GetAttributes()
      {
        return TypeDescriptor.GetAttributes(this, noCustomTypeDesc: true);
      }
      string ICustomTypeDescriptor.GetClassName()
      {
        return TypeDescriptor.GetClassName(this, noCustomTypeDesc: true);
      }
      string ICustomTypeDescriptor.GetComponentName()
      {
        return TypeDescriptor.GetComponentName(this, noCustomTypeDesc: true);
      }
      TypeConverter ICustomTypeDescriptor.GetConverter()
      {
        return TypeDescriptor.GetConverter(this, noCustomTypeDesc: true);
      }
      EventDescriptor ICustomTypeDescriptor.GetDefaultEvent()
      {
        return TypeDescriptor.GetDefaultEvent(this, noCustomTypeDesc: true);
      }
      PropertyDescriptor ICustomTypeDescriptor.GetDefaultProperty()
      {
        return TypeDescriptor.GetDefaultProperty(this, noCustomTypeDesc: true);
      }
      object ICustomTypeDescriptor.GetEditor(Type editorBaseType)
      {
        return TypeDescriptor.GetEditor(this, editorBaseType, noCustomTypeDesc: true);
      }
      EventDescriptorCollection ICustomTypeDescriptor.GetEvents()
      {
        return TypeDescriptor.GetEvents(this, noCustomTypeDesc: true);
      }
      EventDescriptorCollection ICustomTypeDescriptor.GetEvents(Attribute[] attributes)
      {
        return TypeDescriptor.GetEvents(this, attributes, noCustomTypeDesc: true);
      }
      PropertyDescriptorCollection ICustomTypeDescriptor.GetProperties(Attribute[] attributes)
      {
        return TypeDescriptor.GetProperties(this, attributes, noCustomTypeDesc: true);
      }
      object ICustomTypeDescriptor.GetPropertyOwner(PropertyDescriptor pd)
      {
        return this;
      }
      #endregion
    }
