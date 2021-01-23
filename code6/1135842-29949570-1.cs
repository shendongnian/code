    private void dg2_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
    {
        DataGridTemplateColumn dataGridTemplateColumn = new DataGridTemplateColumn();
    
        FrameworkElementFactory fefTextBlock1
            = new FrameworkElementFactory(typeof(TextBlock));
        fefTextBlock1.SetValue(TextBlock.TextProperty, "Kassett");
    
        FrameworkElementFactory fefTextBlock2
            = new FrameworkElementFactory(typeof(TextBlock));
        fefTextBlock2.SetBinding(TextBlock.TextProperty, new Binding("KassettNr"));
    
        FrameworkElementFactory fefTextBlock3
            = new FrameworkElementFactory(typeof(TextBlock));
        fefTextBlock3.SetBinding(TextBlock.TextProperty, new Binding("Varenr"));
    
        FrameworkElementFactory fefTextBlock4
            = new FrameworkElementFactory(typeof(TextBlock));
        fefTextBlock4.SetBinding(TextBlock.TextProperty, new Binding("Varenavn"));
    
        FrameworkElementFactory fefStackPanel
            = new FrameworkElementFactory(typeof(StackPanel), "stackPanel");
    
        fefStackPanel.SetBinding(FrameworkElement.DataContextProperty,
            new Binding(e.PropertyName));
        fefStackPanel.SetValue(FrameworkElement.MarginProperty, new Thickness(5));
        fefStackPanel.AppendChild(fefTextBlock1);
        fefStackPanel.AppendChild(fefTextBlock2);
        fefStackPanel.AppendChild(fefTextBlock3);
        fefStackPanel.AppendChild(fefTextBlock4);
    
        dataGridTemplateColumn.CellTemplate = new DataTemplate();
        dataGridTemplateColumn.CellTemplate.VisualTree = fefStackPanel;
        dataGridTemplateColumn.CellTemplate.Seal();
    
        e.Column = dataGridTemplateColumn;
    }
