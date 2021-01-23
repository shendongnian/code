    private void CanExecute(object sender, CanExecuteRoutedEventArgs e)
    {
        e.CanExecute = IsValid(sender as DependencyObject);
    }
    
    private bool IsValid(DependencyObject obj)
    {
        // The dependency object is valid if it has no errors and all
        // of its children (that are dependency objects) are error-free.
        return !Validation.GetHasError(obj) &&
        LogicalTreeHelper.GetChildren(obj)
        .OfType<DependencyObject>()
        .All(IsValid);
    }
