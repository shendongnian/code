    void MoveFromSQLToDBF()
    {    
        // have a table to pull down your SQL Data...
        var dataFromSQL = new DataTable();
        
        // However your connection to your SQL-Server
        using (var sqlConn = new  SqlConnection("YourSQLConnectionString"))
        {
           using (var sqlCmd = new SqlCommand("", sqlConn))
           {
              // Get all records from your table
              sqlCmd.CommandText = "select * from CountryMaster";
              sqlConn.Open();
              var sqlDA = new SqlDataAdapter();
              // populate into a temp C# table
              sqlDA.Fill(dataFromSQL);
              sqlConn.Close();
           }
        }
        
        // Now, create a connection to VFP 
        // connect to a PATH where you want the data.
        using (var vfpConn = new OleDbConnection(@"Provider=VFPOLEDB.1;Data Source=C:\SomePathOnYourMachine\"))
        {
           using (var vfpCmd = new OleDbCommand("", vfpConn))
           {
              // Create table command for VFP
              vfpCmd.CommandText = "CREATE TABLE testFromSQL ( ID Numeric(18,0), [Name] Char(100) NULL, [Details] Char(200) NULL, [Status] Logical NULL, [CreateDate] DATETIME NULL)";
        
              vfpConn.Open();
              vfpCmd.ExecuteNonQuery();
        
              // Now, change the command to a SQL-Insert command, but PARAMETERIZE IT.
              // "?" is a place-holder for the data
              vfpCmd.CommandText = "insert into testFromSQL "
                 + "( ID, [Name], [Details], [Status], [CreateDate]) value ( ?, ?, ?, ?, ? )";
        
              // Parameters added in order of the INSERT command above.. 
              // SAMPLE values just to establish a basis of the column types
              vfpCmd.Parameters.Add( new OleDbParameter( "parmID", 10000000 ));
              vfpCmd.Parameters.Add( new OleDbParameter( "parmName", "sample string" ));
              vfpCmd.Parameters.Add(new OleDbParameter( "parmDetails", "sample string" ));
              vfpCmd.Parameters.Add(new OleDbParameter( "parmStatus", "sample string" ));
              vfpCmd.Parameters.Add( new OleDbParameter( "parmCreateDate", DateTime.Now ));
        
              // Now, for each row in the ORIGINAL SQL table, apply the insert to VFP
              foreach (DataRow dr in dataFromSQL.Rows)
              {
                 // set the parameters based on whatever current record is
                 vfpCmd.Parameters[0].Value = dr["ID"];
                 vfpCmd.Parameters[1].Value = dr["Name"];
                 vfpCmd.Parameters[2].Value = dr["Details"];
                 vfpCmd.Parameters[3].Value = dr["Status"];
                 vfpCmd.Parameters[4].Value = dr["CreateDate"];
                 // execute it
                 vfpCmd.ExecuteNonQuery();
              }
        
              // close VFP connection
              vfpConn.Close();
           }
        }
    }
