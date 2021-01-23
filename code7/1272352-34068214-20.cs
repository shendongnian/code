    public abstract class ViewModel : INotifyPropertyChanged, IDataErrorInfo
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            // updating property-bound controls
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            // updating command-bound controls like buttons
            CommandManager.InvalidateRequerySuggested();
        }
        private readonly ObservableCollection<ViewModelError> validationErrors = new ObservableCollection<ViewModelError>();
        private void RemoveValidationErrors(string propertyName)
        {
            var propertyValidationErrors = validationErrors
                .Where(_ => _.PropertyName == propertyName)
                .ToArray();
            foreach (var error in propertyValidationErrors)
            {
                validationErrors.Remove(error);
            }
        }
        private string ValidateProperty(string propertyName)
        {
            // we need localized property name
            var property = GetType().GetProperty(propertyName);
            var displayAttribute = property.GetCustomAttribute<DisplayAttribute>();
            var propertyDisplayName = displayAttribute != null ? displayAttribute.GetName() : propertyName;
            // since validation engine run all validation rules for property,
            // we need to remove validation errors from the previous validation attempt
            RemoveValidationErrors(propertyDisplayName);
            // preparing validation engine
            var validationContext = new ValidationContext(this, null, null) { MemberName = propertyName };
            var validationResults = new List<ValidationResult>();
            // running validation
            if (!Validator.TryValidateProperty(property.GetValue(this), validationContext, validationResults))
            {
                // validation is failed;
                // since there could be several validation rules per property, 
                // validation results can contain more than single error
                foreach (var result in validationResults)
                {
                    validationErrors.Add(new ViewModelError(propertyDisplayName, result.ErrorMessage));
                }
                // to indicate validation error, it's enough to return first validation message
                return validationResults[0].ErrorMessage;
            }
            return null;
        }
        public IEnumerable<ViewModelError> ValidationErrors
        {
            get { return validationErrors; }
        }
        public string this[string columnName]
        {
            get { return ValidateProperty(columnName); }
        }
        public string Error
        {
            get { return null; }
        }
    }
