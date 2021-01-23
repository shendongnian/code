    public interface IMvvmTypeLocator
    {
        #region Public Methods and Operators
        Type GetViewModelTypeFromViewType(Type viewType);
        Type GetViewTypeFromViewModelType(Type viewModelType);
        Type GetViewTypeFromViewName(string viewName);
        #endregion
    }
