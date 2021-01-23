    protected virtual void SetProperty<T>(
        string propertyName,
        ref T oldValue,
        T newValue,
        Action onChanged = null)
    {
        if (Equals(oldValue, newValue)) return;
        oldValue = newValue;
        onChanged?.Invoke(); // Invoke the onChanged action (if not null).
        OnPropertyChanged(propertyName);
    }
    protected override void SetProperty<T>(
        string propertyName,
        ref T oldValue,
        T newValue,
        Action onChanged = null)
    {
        // Wrap the given onChanged callback with a new one that also validates the property.
        base.SetProperty(propertyName, ref oldValue, newValue,
            () => { onChanged?.Invoke(); ValidateProperty(propertyName, newValue); });
    }
