    private void add_template_Click(object sender, RoutedEventArgs e)
    {
        root.Children.Clear();
        foreach (UIElement child in Template_canvas1.Children)
        {
            var xaml = System.Windows.Markup.XamlWriter.Save(child);
            var deepCopy = System.Windows.Markup.XamlReader.Parse(xaml) as UIElement;
            root.Children.Add(deepCopy);
        }
    }
