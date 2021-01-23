    private DataGridTemplatColumn CreateColumn(string key)
    {
        DataGridTemplateColumn tmpltColumn = new DataGridTemplateColumn();
        tmpltColumn.Header = key;
    
        // Make the parts for the template
        FrameworkElementFactory tb = new FrameworkElementFactory(typeof(TextBlock));
        Binding b = new Binding($"[{key}].Name");
        tb.SetBinding(TextBlock.TextProperty, b);
    
        FrameworkElementFactory tb1 = new FrameworkElementFactory(typeof(TextBlock));
        Binding b1 = new Binding();
        b1.Path = new PropertyPath($"[{key}].Room");
        tb1.SetBinding(TextBlock.TextProperty, b1);
    
        FrameworkElementFactory sb = new FrameworkElementFactory(typeof(StackPanel));
        sb.AppendChild(tb);
        sb.AppendChild(tb1);
        DataTemplate dt = new DataTemplate { VisualTree = sb };
        dt.Seal();
        tmpltColumn.CellTemplate = dt;
            
        return tmpltColumn;
    }
