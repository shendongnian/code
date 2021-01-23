       public static readonly DependencyProperty PropertyTypeProperty = DependencyProperty.Register(
            "PropertyType", typeof (propertyType), typeof (PasswordBoxDP), new PropertyMetadata((x, y) =>
            {
                var userControlClass = x as UserControlClass;
                userControlClass.Validate();
            }));
        private void Validate()
        {
            
        }
