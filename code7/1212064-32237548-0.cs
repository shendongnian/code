    static void Main(string[] args)
    {
      DirectoryInfo source      = new DirectoryInfo( args[0] ) ;
      DirectoryInfo destination = new DirectoryInfo( args[1] ) ;
      
      HashSet<string> filesToBeCopied = new HashSet<string>( ReadFileNamesFromDatabase() , StringComparer.OrdinalIgnoreCase ) ;
      
      // you'll probably have to play with MaxDegreeOfParallellism so as to avoid swamping the i/o system
      ParallelOptions options= new ParallelOptions { MaxDegreeOfParallelism = 4 } ;
      
      Parallel.ForEach( filesToBeCopied.SelectMany( fn => source.EnumerateFiles( fn ) ) , options , fi => {
          string destinationPath = Path.Combine( destination.FullName , Path.ChangeExtension( fi.Name , ".jpg") ) ;
          fi.CopyTo( destinationPath , false ) ;
      }) ;
      
    }
    
    public static IEnumerable<string> ReadFileNamesFromDatabase()
    {
      using ( SqlConnection connection = new SqlConnection( "connection-string" ) )
      using ( SqlCommand cmd = connection.CreateCommand() )
      {
        cmd.CommandType = CommandType.Text ;
        cmd.CommandText = @"
          select idPic ,
                 namePicFile
          from DocPicFiles
          " ;
        
        connection.Open() ;
        using ( SqlDataReader reader = cmd.ExecuteReader() )
        {
          while ( reader.Read() )
          {
            yield return reader.GetString(1) ;
          }
        }
        connection.Close() ;
      }
    }
