     public override void OnApplyTemplate()
    {
      base.OnApplyTemplate();
      dataGrid = GetTemplateChild("dataGrid") as DataGrid;
      dataGrid.MouseUp += new MouseButtonEventHandler(dataGrid_MouseUp);
      docGrid = GetTemplateChild("docGrid") as DataGrid;
      docGrid.MouseUp += new MouseButtonEventHandler(docGrid_MouseUp);
    }
    public void dataGrid_MouseUp(object sender, MouseEventArgs e)
    {
      docGrid.UnselectAll();
    }
    public void docGrid_MouseUp(object sender, MouseEventArgs e)
    {
      dataGrid.UnselectAll();
    }
