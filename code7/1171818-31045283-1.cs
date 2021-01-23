    private void comboBox_Loaded(object sender, RoutedEventArgs e)
    {
        ComboBox comboBox = (ComboBox)e.OriginalSource;
        BindingOperations.GetBindingExpression(comboBox, ComboBox.SelectedValueProperty)
                         .UpdateTarget();
    }
