    static void DoSomeMethod( )
    {
      Tracer.TraceRun( "DoSomeMethod", ( ) =>
      {
        //--> body of method...
        var x = DoSomeFunction( );
      } );
    }
    static int DoSomeFunction( )
    {
      return Tracer.TraceRun( "DoSomeFunction", ( ) =>
      {
        //--> body of method...
        return 9 - DoSomeFunctionWithArgs( 3 );
      } );
    }
    static int DoSomeFunctionWithArgs( int arg )
    {
      return Tracer.TraceRun( "DoSomeFunctionWithArgs", ( ) =>
      {
        //--> body of method...
        return 1 + arg;
      }, arg );
    }
