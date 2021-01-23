    using Ionic.Zlib;
    ...
    string firstLine = null ;
    string lastLine = null ;
    
    using ( FileStream input = File.Open( @"c:\foo\bar\bazbat.gz" , FileMode.Open , FileAccess.Read , FileShare.Read ) )
    using ( GZipStream gzip = new GZipStream( input , CompressionMode.Decompress ) )
    using ( StreamReader reader = new StreamReader( gzip ) )
    {
      firstLine = lastLine = reader.ReadLine() ;
      while ( null != (lastLine=reader.ReadLine()) )
      {
        // This space intentionally left blank
      }
    }
