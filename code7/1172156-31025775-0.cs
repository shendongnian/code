    public class EditableValue<T> : BindableBase where T : struct
    {
        private T _value;
        private T? _displayValue;
    
        public T Value
        {
            get { return _value; }
            set
            {
                _value = value;
                OnPropertyChanged(() => Value);
            }
        }
    
        public T DisplayValue
        {
            get { return _displayValue ?? Value; }
            set
            {
                _displayValue = value;
                OnPropertyChanged(() => DisplayValue);
            }
        }
    
        public bool HasChanges
        {
            get { return _displayValue.HasValue; }
        }
    
        public void DiscardChanges()
        {
            _displayValue = null;
            OnPropertyChanged(() => DisplayValue);
        }
    
        public void ApplyChanges()
        {
            Value = DisplayValue;
            OnPropertyChanged(() => DisplayValue);
            OnPropertyChanged(() => Value);
        }
    }
