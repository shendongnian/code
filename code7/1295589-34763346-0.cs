        DataGridTemplateColumn buttonColumn = new DataGridTemplateColumn();
        DataTemplate buttonTemplate = new DataTemplate();
        FrameworkElementFactory buttonFactory = new         FrameworkElementFactory(typeof (Button));
        buttonTemplate.VisualTree = buttonFactory;
        //add binding to command if you want to handle click
        buttonFactory.SetValue(ContentProperty, "Button");
        buttonColumn.CellTemplate = buttonTemplate;
        grdDummy.Columns.Add(buttonColumn);
