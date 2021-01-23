     protected void ExpExcel_Click(object sender, EventArgs e)
        {
            //exclude columns from being exported in excel
            foreach (GridColumn col in RadGrid1.MasterTableView.Columns)
            {
                if ((col.UniqueName.Contains("EditCommandColumn")) ||
                    (col.UniqueName.Contains("column1")))
                {
                    col.Display = false;
                }
                else
                {
                    col.Display = true;
                }
            }
            //format content to be exported in excel
            foreach (GridFilteringItem item in RadGrid1.MasterTableView.GetItems(GridItemType.FilteringItem))
    
            item.Visible = false;
           //the other settings you need...
            RadGrid1.ExportSettings.FileName = "yourFileName;
            RadGrid1.ExportSettings.ExportOnlyData = true;
            RadGrid1.ExportSettings.Excel.Format = Telerik.Web.UI.GridExcelExportFormat.ExcelML;
           //example of renaming column header in excel            
            RadGrid1.MasterTableView.Columns.FindByUniqueName("something").HeaderText = "something else";
            RadGrid1.MasterTableView.ExportToExcel();
        }
