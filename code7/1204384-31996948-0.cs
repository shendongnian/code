    public void SerializeContainer( XmlWriter writer, Container obj )
    {
      try
      {
        // Make sure even the construsctor runs inside a
        // try-catch block
        XmlSerializer ser = new XmlSerializer( typeof(Container));
        ser.Serialize( writer, obj );
      }
      catch( Exception ex )               
      {                                   
        DumpException( ex );             
      }                                   
    }
    public static void DumpException( Exception ex )
    {
      Console.WriteLine( "--------- Outer Exception Data ---------" );        
      WriteExceptionInfo( ex );
      ex = ex.InnerException;                     
      if( null != ex )               
      {                                   
        Console.WriteLine( "--------- Inner Exception Data ---------" );                
        WriteExceptionInfo( ex.InnerException );    
        ex = ex.InnerException;
      }
    }
    public static void WriteExceptionInfo( Exception ex )
    {
      Console.WriteLine( "Message: {0}", ex.Message );                  
      Console.WriteLine( "Exception Type: {0}", ex.GetType().FullName );
      Console.WriteLine( "Source: {0}", ex.Source );                    
      Console.WriteLine( "StrackTrace: {0}", ex.StackTrace );           
      Console.WriteLine( "TargetSite: {0}", ex.TargetSite );            
    }
