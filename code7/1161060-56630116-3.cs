    Bind.BindGridView(DataGridView, actionResult.dtResult);
        
    if (DataGridView.Rows.Count > 0)
    {
      DataGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
    }
    DataGridView.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
    DataGridView.HeaderRow.Cells[1].Attributes["data-hide"] = "phone";
    DataGridView.HeaderRow.Cells[2].Attributes["data-hide"] = "phone";
    DataGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
