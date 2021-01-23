    DataTable table = new DataTable("dt1");
    
            foreach (Telerik.WinControls.UI.GridViewDataColumn column in radGridView1.Columns)
            {
                table.Columns.Add(column.Name, typeof(string));
            }
            for (int i = 0; i < radGridView1.Rows.Count; i++)
            {
                    table.Rows.Add();
                    for (int j = 0; j < radGridView1.Columns.Count; j++)
                    {
                        table.Rows[i][j] = radGridView1.Rows[i].Cells[j].Value;
                    }                
            }
    
            DataSet ds = new DataSet();
            ds.Tables.Add(table);
    		var dv = ds.Tables[0].DefaultView;
            var strExpr = "ItemID = 1"; //Change accordingly
    		dv.RowFilter = strExpr;
    		var newDT = dv.ToTable();
            StiReport stiReport = new StiReport();
            stiReport.Load("Report.mrt");
            stiReport.RegData(newDT);
            StiOptions.Viewer.Windows.ShowPageDesignButton = false;
            StiOptions.Viewer.Windows.ShowOpenButton = false;
            //stiReport.Design();
            stiReport.Show();
