    string colProperty = "Name";
    
    DataGridTextColumn col = new DataGridTextColumn();
    col.Binding = new Binding(colProperty);
    var spHeader = new StackPanel() { Orientation = Orientation.Horizontal };
    spHeader.Children.Add(new TextBlock(new Run(colProperty)));
    Button button1 = new Button();
    button1.Click += Button_Filter_Click;
    button1.Content = "Edit";
    spHeader.Children.Add(button1);
    
    col.Header = spHeader;
    
    dataGrid.Columns.Add(col);
