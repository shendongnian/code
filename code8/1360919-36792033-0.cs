    class MyCollectionEditor : TypeEditor<CollectionControlButton>
    {
      protected override void SetValueDependencyProperty()
      {
        ValueProperty = CollectionControlButton.ItemsSourceProperty;
      }
      protected override void ResolveValueBinding(PropertyItem propertyItem)
      {
        var type = propertyItem.PropertyType;
        Editor.ItemsSourceType = type;
        // added
        AttributeCollection attrs = propertyItem.PropertyDescriptor.Attributes;
        Boolean attrFound = false;
        foreach(Attribute attr in attrs)
        {
          if (attr is NewItemTypesAttribute)
          {
            Editor.NewItemTypes = ((NewItemTypesAttribute)attr).Types;
            attrFound = true;
            break;
          }
        }
        // end added
        if (!attrFound)
        {
          if (type.BaseType == typeof(System.Array))
          {
            Editor.NewItemTypes = new List<Type>() { type.GetElementType() };
          }
          else if (type.GetGenericArguments().Count() > 0)
          {
            Editor.NewItemTypes = new List<Type>() { type.GetGenericArguments()[0] };
          }
        }
        base.ResolveValueBinding(propertyItem);
      }
    }
