    private void OnValidationChanged(string propertyName, ValidationResult validationResult)
    {
        var vm = DataContext as ViewModelBase;
         
        if (vm != null)
        {
            if (validationResult.IsValid)
            {
                vm.ClearValidationErrorFromView(propertyName);
            }
            else
            {
                vm.AddValidationErrorFromView(propertyName, validationResult.ErrorContent as string);
            }
        }
    }
