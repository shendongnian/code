    DataTemplate template = new DataTemplate();
    FrameworkElementFactory factory = new FrameworkElementFactory(typeof(StackPanel));
    template.VisualTree = factory;
    FrameworkElementFactory childFactory = new FrameworkElementFactory(typeof(CheckBox));
    childFactory.SetBinding(CheckBox.IsChecked, new Binding("IsSelected"));
    factory.AppendChild(childFactory);
    childFactory = new FrameworkElementFactory(typeof(TextBox));
    childFactory.SetBinding(Label.ContentProperty, new Binding("Description"));
    factory.AppendChild(childFactory);
