    private void Transfer()
    {
     DataTable dT = GetDataTableFromDGV(dataGridView1);
     dSet.Tables.Add(dT);
     try
         {
         dSet.AcceptChanges();
         dSet.WriteXml(@"C:\MyData.xml", XmlWriteMode.WriteSchema);
          }
     catch (FileLoadException) { }
     ReportDocument cr = new ReportDocument();
            string filePath = @"C:\CrystalReportData.rpt";
            cr.Load(filePath);
            cr.SetDataSource(dSet);
            crystalReportViewer1.ReportSource = cr;
    }
