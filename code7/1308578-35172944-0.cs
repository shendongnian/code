    try
    {
        this.PrintPreview.Child = GetLabelPreviewControl(labelPath);
        Binding previewBinding = new Binding();
        previewBinding.Source = this.PrintPreview.DataContext;
        previewBinding.Mode = BindingMode.TwoWay; //Set the binding to Two-Way mode
        (this.PrintPreview.Child as FrameworkElement).SetBinding(FrameworkElement.DataContextProperty, previewBinding);
    }
    catch (Exception ex)
    {
        // Handle Exception Stuff here...
    }
