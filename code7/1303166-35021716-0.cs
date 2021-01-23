    private void txt_GotFocus(object sender, RoutedEventArgs e)
    {
        TextBox tb = (TextBox) sender;
        BindingExpression BE = tb.GetBindingExpression(TextBox.TextProperty);
        Binding B = BE.ParentBinding;
        PropertyPath P = B.Path;
        
        Binding NewBinding = new Binding(P.Path.Replace(".Abb", ""));
        NewBinding.Mode = BindingMode.TowWay;
        lbUnits.SetBinding(ListBox.SelectedItemProperty, NewBinding);
        //Hide Panorama
        Panorama.Visibility = System.Windows.Visibility.Collapsed;
        // Show ListBoxGrid
        LengthUnits.Visibility = System.Windows.Visibility.Visible;
    }
