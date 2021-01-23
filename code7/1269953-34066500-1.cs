    private void Grid_Loaded(object sender, RoutedEventArgs e)
    {
        var grid = (Grid)sender;
        //the actual transformation
        var render = (Transform)grid.GetValue(RenderTransformProperty);
        //the field the transformation is bound to
        var field = (Field)grid.DataContext;
        //for now this only works in WPF
        var binding = BindingOperations.GetBinding(render, TranslateTransform.XProperty);
    }
