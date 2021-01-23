        string queryString = "Select Ledger.`$_Name`, Ledger.`$_ClosingBalance`, Ledger.`$_OpeningBalance` FROM AshtaMunicipalCouncil.TallyUser.Ledger Ledger"";
        OdbcDataAdapter adapter = new OdbcDataAdapter(queryString, con);
        DataSet1 ds1 = new DataSet1();
        // Open the connection and fill the DataSet.
        try
        {
            con.Open();
            adapter.Fill(ds1,"tbl");
            con.Close();
        }
        catch (Exception ex
        {
            Console.WriteLine(ex.Message);
        }
      // you can check your table count there
       MessageBox.Show (ds1.DataTable1.Rows.Count.ToString());
       CrystalReport1 crv = new CrystalReport1();
       crv.SetDataSource(ds1.DataTable1);
       crystalReportViewer1.ReportSource = crv;
       crystalReportViewer1.RefreshReport();
       
