    static List<List<string>> GetDataFromDatabase()
    {
      List<List<string>> dataset = new List<List<string>>() ;
      
      using ( SqlConnection conn = new SqlConnection( "Server=localhost;Database=sandbox;Trusted_Connection=True;" ) )
      using ( SqlCommand cmd = conn.CreateCommand() )
      {
        
        cmd.CommandText = "select * from sys.objects" ;
        cmd.CommandType = CommandType.Text ;
        
        conn.Open() ;
        
        using ( SqlDataReader reader = cmd.ExecuteReader() )
        {
          
          List<string> columnNames = Enumerable.Range(0,reader.FieldCount).Select( i => reader.GetName(i) ).ToList() ;
          dataset.Add( columnNames ) ;
          
          dataset.AddRange(
            reader
            .Cast<IDataRecord>()
            .Select(
              record => Enumerable
                        .Range(0,record.FieldCount)
                        .Select( i => record[i].ToString() )
                        .ToList()
            )
            .ToList()
          ) ;
          reader.Close() ;
        }
        conn.Close() ;
      }
      return dataset ;
    }
