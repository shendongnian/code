         string Connectionstr = "";      
          string filePath ="C:\Sample.xlsx";
          string fileExtension = Path.GetExtension(filePath).ToLower();
    
          if (fileExtension == ".xls")
          Connectionstr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath + ";" + "Extended Properties='Excel 8.0;HDR=YES;IMEX=1'";
          if (fileExtension == ".xlsx")
          Connectionstr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + ";" + "Extended Properties='Excel 12.0 Xml;HDR=YES;IMEX=1'";
            MyConnection = new System.Data.OleDb.OleDbConnection(Connectionstr);
            MyCommand = new System.Data.OleDb.OleDbDataAdapter("select * from [Sheet1$]", MyConnection);
           MyCommand.TableMappings.Add("Table", "Net-informations.com");
            DtSet = new System.Data.DataSet();
           MyCommand.Fill(DtSet);
           dgvInitial.Columns.Clear();
           dgvInitial.AutoGenerateColumns = true;
           dgvInitial.DataSource = DtSet.Tables[0];
            MyConnection.Close();
