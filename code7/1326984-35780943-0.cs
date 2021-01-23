    protected override FrameworkElement GenerateEditingElement(DataGridCell cell, object dataItem)
    {
        // Create our ObjectProxy that will update our dataItem's ColumnName property
        var op = new ObjectProxy(dataItem, ColumnName);
        // Generate the editing element using our ObjectProxy
        var cp = (ContentPresenter)base.GenerateEditingElement(cell, op);
        // Reset the Binding to our ObjectProxy
        BindingOperations.SetBinding(cp, ContentPresenter.ContentProperty, new Binding(".") { Source = op });
        return cp;
    }
