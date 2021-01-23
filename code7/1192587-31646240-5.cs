    public class GenericRow : CustomTypeDescriptor, INotifyPropertyChanged
    {
        #region Private Fields
        List<PropertyDescriptor> _property_list = new List<PropertyDescriptor>();
        #endregion
        #region INotifyPropertyChange Implementation
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion INotifyPropertyChange Implementation
        #region Public Methods
        public void SetPropertyValue<T>(string propertyName, T propertyValue)
        {
            var properties = this.GetProperties()
                                    .Cast<PropertyDescriptor>()
                                    .Where(prop => prop.Name.Equals(propertyName));
            if (properties == null || properties.Count() != 1)
            {
                throw new Exception("The property doesn't exist.");
            }
            var property = properties.First();
            property.SetValue(this, propertyValue);
            OnPropertyChanged(propertyName);
        }
        public T GetPropertyValue<T>(string propertyName)
        {
            var properties = this.GetProperties()
                                .Cast<PropertyDescriptor>()
                                .Where(prop => prop.Name.Equals(propertyName));
            if (properties == null || properties.Count() != 1)
            {
                throw new Exception("The property doesn't exist.");
            }
            var property = properties.First();
            return (T)property.GetValue(this);
        }
        public void AddProperty<T, U>(string propertyName) where U : GenericRow
        {
            var customProperty =
                    new CustomPropertyDescriptor<T>(
                                            propertyName,
                                            typeof(U));
            _property_list.Add(customProperty);
        }
        #endregion
        #region Overriden Methods
        public override PropertyDescriptorCollection GetProperties()
        {
            var properties = base.GetProperties();
            return new PropertyDescriptorCollection(
                                properties.Cast<PropertyDescriptor>()
                                          .Concat(_property_list).ToArray());
        }
        #endregion
    }
