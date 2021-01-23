    void spreadExporter_CellFormatting(object sender, Telerik.WinControls.Export.CellFormattingEventArgs e)
        {
            if (e.GridRowInfoType == typeof(GridViewHierarchyRowInfo))
            {
                int i = 0;
                foreach (GridViewColumn column in radGridView1.MasterTemplate.Templates[0].Columns)
                {
                    if (i > 1)
                    {
                        int TotalNullRecords = (from row in e.GridCellInfo.RowInfo.ChildRows
                                                where string.IsNullOrWhiteSpace(row.Cells[column.Name].Value.ToString())
                                                select row).ToList().Count;
                        if (TotalNullRecords == e.GridCellInfo.RowInfo.ChildRows.Count)
                        {
                            radGridView1.MasterTemplate.Templates[0].Columns[column.Name].IsVisible = false;
                        }
                        else
                            radGridView1.MasterTemplate.Templates[0].Columns[column.Name].IsVisible = true;
                    }
                    i++;
                }
            }
        }
