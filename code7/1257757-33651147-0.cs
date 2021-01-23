    var x = itemsControl.ContainerFromItem(item) as ContentPresenter;
    Paragraph p = new Paragraph();
    InlineUIContainer c = new InlineUIContainer();
    var o = x.ContentTemplate.LoadContent() as UIElement;
    (o as FrameworkElement).DataContext = item;
    (o as FrameworkElement).Margin = new Thickness(40);
