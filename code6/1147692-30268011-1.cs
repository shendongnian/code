    public static void Concatenate( IEnumerable<FileInfo> files , FileInfo destination , bool overWriteDestination = true )
    {
      FileMode mode = overWriteDestination ? FileMode.Create : FileMode.Append ;
      
      using ( FileStream tgt = destination.Open( mode , FileAccess.Write , FileShare.Read ) )
      {
        foreach( FileInfo file in files )
        {
          using ( FileStream src = file.Open( FileMode.Open , FileAccess.Read , FileShare.Read ) )
          {
            const int bufferSize = 64*1024; // 64k buffer OK?
            src.CopyTo( tgt , bufferSize ) ;
          }
        }
        tgt.Flush() ;
      }
      
      return;
    }
    ...
    DirectoryInfo dir = new DirectoryInfo( @"C:\foo") ;
    FileInfo target = new FileInfo( @"C:\foo.glob") ;
    Concatenate( dir.EnumerateFiles( "*.*" ) , target , true ) ;
