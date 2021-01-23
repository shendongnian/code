    [DataContract(IsReference = true)]
    [Serializable]
    public abstract class EntityBase : INotifyPropertyChanged, IDataErrorInfo
    {
        #region Fields
        
        //This hold the property name and its value
        private Dictionary<string, object> _values = new Dictionary<string, object>();
        #endregion Fields
        #region Action
        //Subscribe this event if want to know valid changed
        public event Action IsValidChanged;
        #endregion
        #region Protected
        protected void SetValue<T>(Expression<Func<T>> propertySelector, T value)
        {
            string propertyName = GetPropertyName(propertySelector);
            SetValue(propertyName, value);
        }
        protected void SetValue<T>(string propertyName, T value)
        {
            if (string.IsNullOrEmpty(propertyName))
                throw new ArgumentException("Invalid property name", propertyName);
            _values[propertyName] = value;
            NotifyPropertyChanged(propertyName);
            if (IsValidChanged != null)
                IsValidChanged();
        }
        protected T GetValue<T>(Expression<Func<T>> propertySelector)
        {
            string propertyName = GetPropertyName(propertySelector);
            return GetValue<T>(propertyName);
        }
        protected T GetValue<T>(string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName))
                throw new ArgumentNullException("invalid property name",propertyName);
            object value;
            if (!_values.TryGetValue(propertyName, out value))
            {
                value = default(T);
                _values.Add(propertyName, value);
            }
            return (T)value;
        }
        protected virtual string OnValidate(string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName))
                throw new ArgumentNullException("propertyName","invalid property name");
            string error = string.Empty;
            object value = GetValue(propertyName);
            //Get only 2 msgs
            var results = new List<ValidationResult>(2);
            bool result = Validator.TryValidateProperty(value,new ValidationContext(this, null, null){MemberName = propertyName},results);
            //if result have errors or for the first time dont set errors
            if (!result && (value == null || ((value is int || value is long) && (int)value == 0) || (value is decimal && (decimal)value == 0)))
                return null;
            if (!result)
            {
                ValidationResult validationResult = results.First();
                error = validationResult.ErrorMessage;
            }
            return error;
        }
        #endregion Protected
        #region PropertyChanged
        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler == null)
                return;
            var e = new PropertyChangedEventArgs(propertyName);
            handler(this, e);
        }
        protected void NotifyPropertyChanged<T>(Expression<Func<T>> propertySelector)
        {
            PropertyChangedEventHandler propertyChanged = PropertyChanged;
            if (propertyChanged == null)
                return;
            string propertyName = GetPropertyName(propertySelector);
            propertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion PropertyChanged
        #region Data Validation
        string IDataErrorInfo.Error
        {
            get
            {
                throw new NotSupportedException("IDataErrorInfo.Error is not supported, use IDataErrorInfo.this[propertyName] instead.");
            }
        }
        string IDataErrorInfo.this[string propertyName]
        {
            get { return OnValidate(propertyName); }
        }
        #endregion Data Validation
        #region Privates
        private static string GetPropertyName(LambdaExpression expression)
        {
            var memberExpression = expression.Body as MemberExpression;
            if (memberExpression == null)
            {
                throw new InvalidOperationException();
            }
            return memberExpression.Member.Name;
        }
        private object GetValue(string propertyName)
        {
            object value = null;
            if (!_values.TryGetValue(propertyName, out value))
            {
                PropertyDescriptor propertyDescriptor = TypeDescriptor.GetProperties(GetType()).Find(propertyName, false);
                if (propertyDescriptor == null)
                    throw new ArgumentNullException("propertyName","invalid property");
                value = propertyDescriptor.GetValue(this);
                if (value != null)
                    _values.Add(propertyName, value);
            }
            return value;
        }
        #endregion Privates
        #region Icommand Test
        public bool IsValid
        {
            get
            {
                if (_values == null)
                    return true;
                //To validate each property which is in _values dictionary
                return _values
                    .Select(property => OnValidate(property.Key))
                    .All(errorMessages => errorMessages != null && errorMessages.Length <= 0);
            }
        }
        #endregion Icommand Test
    }
