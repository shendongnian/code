    private void Report4_NeedDataSource(object sender, EventArgs e)
    {
      DataTable dt = new DataTable();
      dt = SalesReport.reportDataTable;
      table1.DataSource = dt;
    
      //Telerik.Reporting.HtmlTextBox textboxGroup; 
      //Telerik.Reporting.HtmlTextBox textBoxTable; 
      table1.ColumnGroups.Clear();
      table1.Body.Columns.Clear();
      table1.Body.Rows.Clear();
      int ColCount = dt.Columns.Count;
    
      for (int i = 0; i <= ColCount - 1; i++)
      {
        Telerik.Reporting.TableGroup tableGroupColumn = new Telerik.Reporting.TableGroup();
        table1.ColumnGroups.Add(tableGroupColumn);
        var textboxGroup = new Telerik.Reporting.HtmlTextBox();
        textboxGroup.Style.BorderColor.Default = Color.Black;
        textboxGroup.Style.BorderStyle.Default = BorderType.Solid;
        textboxGroup.Value = dt.Columns[i].ColumnName;
        textboxGroup.Size = new SizeU(Unit.Inch(1.5), Unit.Inch(0.6));
        tableGroupColumn.ReportItem = textboxGroup;
        var textBoxTable = new Telerik.Reporting.HtmlTextBox();
        textBoxTable.Value = "=Fields." + dt.Columns[i].ColumnName;
        textBoxTable.Size = new SizeU(Unit.Inch(1.1), Unit.Inch(0.3));
        table1.Body.SetCellContent(0, i, textBoxTable);
        table1.Items.AddRange(new ReportItemBase[] { textBoxTable, textboxGroup });
      }
    
    }
