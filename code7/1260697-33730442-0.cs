     void TransferDataToReport()
        {
             DataTable dT = GetDataTableFromDGV(dataGridView1);
                    dSet.Tables.Add(dT);
                    try
                    {
                        dSet.AcceptChanges();
              dSet.WriteXml(@"C:\Data.xml", XmlWriteMode.WriteSchema);
          }
          catch (FileLoadException) { }
        
         ReportDocument cr = new ReportDocument();
                    string filePath = @"C:\CrystalReportData.rpt";
                    cr.Load(filePath);
                    cr.SetDataSource(dSet);
                    crystalReportViewer1.ReportSource = cr;
        }
     public DataTable GetDataTableFromDGV(DataGridView dgv)
        {
            DataTable dt = new DataTable();
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                dt.Columns.Add(column.Name, column.ValueType);
            }
            object[] cellValues = new object[dgv.Columns.Count];
            foreach (DataGridViewRow row in dgv.Rows)
            {
                for (int i = 0; i < row.Cells.Count; i++)
                {
                    cellValues[i] = row.Cells[i].Value;
                }
                dt.Rows.Add(cellValues);
            }
            return dt;
        }
