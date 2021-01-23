<!-- -->
    3. You can use custom `TypeDescriptor` to create generic wrapper class. In your custom `TypeDescriptor` override GetProperties() method so it will return the same properties as your objects. You will also need to create custom `PropertyDescriptor` with overridden `GetValue` and `SetValue` methods so it works with your collection of objects to edit
        public class MultiEditWrapper<TItem> : CustomTypeDescriptor {
          private ICollection<TItem> _objectsToEdit;
          private MultiEditPropertyDescriptor[] _propertyDescriptors;
          public MultiEditWrapper(ICollection<TItem> objectsToEdit) {
            _objectsToEdit = objectsToEdit;
            _propertyDescriptors = TypeDescriptor.GetProperties(typeof(TItem))
              .Select(p => new MultiEditPropertyDescriptor(objectsToEdit, p))
              .ToArray();  
          }
          public override PropertyDescriptorCollection GetProperties()
          {
            return new PropertyDescriptorCollection(_propertyDescriptors);
          }
        }
