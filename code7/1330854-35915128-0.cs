    void Main()
    {
      using (var exportConnection = new SqlConnection(connectionString: "Data Source=Localhost;"
                                                                       + "Trusted_Connection=yes;"
                                                                       + @"connection timeout=30;"
                                                                       + @"database=001-CARL_V4"))
    
      // your importConnection was wrong
      using (var importConnection = new OleDbConnection(connectionString: @"Provider=vfpoledb.1;"
                                                                   + @"data source=C:\Users\Joshua.cameron\Desktop\PCHomesImportTestBlank\PCHomesServer\DATABASE\pchomes.dbc"))
    
      using (SqlCommand exportCommand = new SqlCommand(@"select * from dbo.CARL_Owners", exportConnection))
    
      using (OleDbCommand importCommand = new OleDbCommand(@"INSERT INTO CLIENT (itle,Fname,Sname) VALUES (?,?,?)",
            importConnection))
      {
        // you shouldn't use an array in between
        // because if the data is large you would be unnecessarily
        // wasting memory. Instead fill the rows in VFP database 
        // as you read data from SQL with the reader.
        // IOW do the process streaming. Read -> insert 
        // You are doing: Read into an array -> insert from array 
        // (but erroneously attempting to read from the reader again)
    
    
        importCommand.Parameters.AddWithValue("Title", "");
        importCommand.Parameters.AddWithValue("Fname", "");
        importCommand.Parameters.AddWithValue("Sname", "");
    
        // Open connections to both
        exportConnection.Open();
        importConnection.Open();
    
        Console.WriteLine("Visual Foxpro connection open");
        new OleDbCommand(@"DELETE FROM CLIENT", importConnection).ExecuteNonQuery();
    
        Console.WriteLine("Writing to table");
        Console.ReadKey();
    
    
        // Initiate the reader to SQL
        var exportReader = exportCommand.ExecuteReader();
    
        // Start reading
        while (exportReader.Read())
        {
          // as you read rows from SQL, set the parameter values
          // I would suggest using (string)row["sourceColumn"]
          // style but reader.GetValue, reader.GetString(index)
          // would work as well - although not safe (what happens
          // if someone modifies the structure of the SQL table a bit?)
    
          // anyway set the values
          importCommand.Parameters["Title"].Value = exportReader.GetString(0);
          importCommand.Parameters["Fname"].Value = exportReader.GetString(1);
          importCommand.Parameters["Sname"].Value = exportReader.GetString(2);
    
          // insert into VFP
          importCommand.ExecuteNonQuery();
        }
        
        // done
        exportConnection.Close();
        importConnection.Close();
      }
    }
