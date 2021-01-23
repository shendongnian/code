    public abstract class NotifyDataErrorModel : INotifyDataErrorInfo
    {
        /// <summary>
        /// Maps properties to their error sets
        /// </summary>
        protected Dictionary<string, HashSet<string>> errors;
        /// <summary>
        /// maps a property to a list of properties 
        /// the list of properties will get the ValidationErrors of the property
        /// </summary>
        protected NotifyDataErrorModel()
        {
            errors = new Dictionary<string, HashSet<string>>();
            var properties = getProperties();
            foreach (var property in properties)
            {
                errors.Add(property, new HashSet<string>());
            }
        }
        private IEnumerable<string> getProperties()
        {
            var properties = this.GetType().GetProperties().Select(p => p.Name).ToList();
            properties.Remove("HasErrors"); //remove the HasErrors property, because it is part of the interface INotifyDataErrorInfo and not of the actual model
            return properties;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="property">the property to validate</param>
        public virtual void ValidateProperty(string property)
        {
            //clear the errors on the matched property
            errors[property].Clear();
            var type = this.GetType();
            //the entity framework proxies sometimes dont inherit the attributes of the properties
            //so if it is a entity framework proxy object, get the base class (which is the actual model class) instead
            if (type.FullName.Contains("System.Data.Entity.DynamicProxies"))
            {
                type = type.BaseType;
            }
            var propertyInfo = type.GetProperty(property);
            var propertyValue = propertyInfo.GetValue(this);
            var validationAttributes = propertyInfo.GetCustomAttributes(true).OfType<ValidationAttribute>();
            foreach (var validationAttribute in validationAttributes)
            {
                if (!validationAttribute.IsValid(propertyValue))
                {
                    errors[property].Add(validationAttribute.FormatErrorMessage(string.Empty));
                }
            }
            raiseErrorsChanged(property);
        }
        public virtual void ValidateAllProperties()
        {
            var properties = getProperties();
            foreach (var property in properties) ValidateProperty(property);
        }
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
        public System.Collections.IEnumerable GetErrors(string propertyName)
        {
            //if the propertyname is not valid, return an empty IEnumerable
            if (String.IsNullOrEmpty(propertyName)) return new List<string>();
            return errors[propertyName];
        }
        public bool HasErrors
        {
            get { return errors.Any((propertyErrors) => propertyErrors.Value.Count > 0); }
        }
        private void raiseErrorsChanged(string property)
        {
            if (ErrorsChanged != null)
            {
                var eventArgs = new DataErrorsChangedEventArgs(property);
                ErrorsChanged(this, eventArgs);
            }
        }
    }
