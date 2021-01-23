    DataGridTemplateColumn col = new DataGridTemplateColumn();
    col.Header = "Actions";
    DataTemplate dt = new DataTemplate();
    var stkpnl = new FrameworkElementFactory(typeof(StackPanel));
    stkpnl .SetValue(StackPanel.OrientationProperty, Orientation.Horizontal);
    var btn1 = new FrameworkElementFactory(typeof(Button));
    btn1.SetValue(Button.ContentProperty, "Delete");
    btn1.AddHandler(Button.ClickEvent, new RoutedEventHandler(btnDelete_Click));
    btn1.SetValue(Button.MarginProperty, new Thickness(0, 0, 10, 0));
    stkpnl.AppendChild(btn1);
    
    var btn2 = new FrameworkElementFactory(typeof(Button));
    btn2.SetValue(Button.ContentProperty, "Edit");
    btn2.AddHandler(Button.ClickEvent, new RoutedEventHandler(btnEdit_Click));
    stkpnl .AppendChild(btn2);
    dt.VisualTree = stkpnl ;
    col.CellTemplate = dt;
    DgEmp.Columns.Add(col);
