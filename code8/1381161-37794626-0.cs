    Binding bin = new Binding();
    bin.Mode = BindingMode.TwoWay;
    bin.Path = new PropertyPath("(0).(1)", Cell.ParentCellProperty, Cell.ContentProperty);
    bin.RelativeSource = RelativeSource.Self;
    FrameworkElementFactory factory = new FrameworkElementFactory(typeof(ComboBox));
    factory.SetValue(ComboBox.SelectedValueProperty, bin);
