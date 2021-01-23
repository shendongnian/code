        DataGridTemplateColumn buttonColumn = new DataGridTemplateColumn();
        DataTemplate buttonTemplate = new DataTemplate();
        FrameworkElementFactory buttonFactory = new FrameworkElementFactory(typeof (Button));
        buttonTemplate.VisualTree = buttonFactory;
        //add handler or you can add binding to command if you want to handle click
        buttonFactory.AddHandler(ButtonBase.ClickEvent, new RoutedEventHandler(HandleClick));
        buttonFactory.SetValue(ContentProperty, "Button");
        buttonColumn.CellTemplate = buttonTemplate;
        grdDummy.Columns.Add(buttonColumn);
