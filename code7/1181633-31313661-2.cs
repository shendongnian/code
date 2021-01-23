        private const string FirstNamePropertyName = "FirstName";
        private string _FirstName;
        public string FirstName
        {
            get
            {
                return _FirstName;
            }
            set
            {
                if (_FirstName == value)
                    return;
                ValidationResult _Result = _NotEmptyRule.Validate(value, System.Globalization.CultureInfo.CurrentCulture);
                if (!_Result.IsValid)
                {
                    AddError(FirstNamePropertyName, ValueIsNullOrBlank);
                }
                else
                {
                    RemoveError(FirstNamePropertyName, ValueIsNullOrBlank);
                }
                _FirstName = value;
                HasChanges = true;
                RaisePropertyChanged(FirstNamePropertyName);
            }
        }
        private const string ValueIsNullOrBlank = "ValueIsNullOrBlank";
        private NotEmptyRule _NotEmptyRule = new NotEmptyRule();
        private Dictionary<string, List<object>> _Errors = new Dictionary<string, List<object>>();
        protected void AddError(string PropertyName, object Error)
        {
            if (!_Errors.ContainsKey(PropertyName))
            {
                _Errors[PropertyName] = new List<object>();
            }
            if (!_Errors[PropertyName].Contains(Error))
            {
                _Errors[PropertyName].Add(Error);
                RaiseErrorsChanged(PropertyName);
            }
        }
        protected void RemoveError(string PropertyName, object Error)
        {
            if (_Errors.ContainsKey(PropertyName) && _Errors[PropertyName].Contains(Error))
            {
                _Errors[PropertyName].Remove(Error);
                if (_Errors[PropertyName].Count == 0)
                {
                    _Errors.Remove(PropertyName);
                }
                RaiseErrorsChanged(PropertyName);
            }
        }
        public void RaiseErrorsChanged(string PropertyName)
        {
            if (ErrorsChanged != null)
                ErrorsChanged(this, new DataErrorsChangedEventArgs(PropertyName));
        }
        public IEnumerable GetErrors(string PropertyName)
        {
            if (String.IsNullOrEmpty(PropertyName) ||
                !_Errors.ContainsKey(PropertyName)) return null;
            return _Errors[PropertyName];
        }
        public bool HasErrors
        {
            get { return _Errors.Count > 0; }
        }
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
        private const string HasChangesPropertyName = "HasChanges";
        private bool _HasChanges;
        public bool HasChanges
        {
            get
            {
                return _HasChanges;
            }
            set
            {
                _HasChanges = value;
                RaisePropertyChanged(HasChangesPropertyName);
            }
        }
