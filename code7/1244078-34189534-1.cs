            DataTable dtInput = new DataTable();
            dtInput = dsAnalystPage.Tables[0];
            foreach (DataColumn cl in dtInput.Columns)
            {
                BrightIdeasSoftware.OLVColumn aNewColumn = new BrightIdeasSoftware.OLVColumn();
                aNewColumn.Name = cl.ColumnName;
                aNewColumn.Text = cl.ColumnName;
                if (aNewColumn.Text == "ASF_Code" || aNewColumn.Text == "ASD_SheetCode" || aNewColumn.Text == "ASD_SheetName")
                {
                    aNewColumn.Width = 0;
                    aNewColumn.IsVisible = false;
                }
                OLV.AllColumns.Add(aNewColumn);
                OLV.RebuildColumns();
            }
