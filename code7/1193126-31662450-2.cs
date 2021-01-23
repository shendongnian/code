    static void Main(string[] args)
    {
      foreach ( string fileName in args )
      {
        string[] lines = File.ReadAllLines( fileName ) ;
        
        for ( int i = 0 ; i < lines.Length ; ++i )
        {
          lines[i] = ApplyTransformHere( lines[i] ) ;
        }
        
        File.WriteAllLines( fileName , lines ) ;
        
      }
      return;
    }
