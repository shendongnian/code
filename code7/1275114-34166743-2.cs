    class Tracer
    {
      [ThreadStatic]
      private static int depth = 0;
      public static void TraceRun( string name, Action method, params object[ ] args )
      {
        TraceStartCall( name, args );
        depth++;
        method( );
        TraceEndCall( );
        depth--;
      }
      public static T TraceRun<T>( string name, Func<T> function, params object[ ] args )
      {
        TraceStartCall( name, args );
        depth++;
        var results = function( );
        TraceEndCall( results );
        depth--;
        return results;
      }
      private static void TraceStartCall( string functionName, params object[ ] args )
      {
        Trace.WriteLine
        (
          string.Format
          (
            "{0}: {1}{2}({3}){{",
            Thread.CurrentThread.ManagedThreadId,
            new string( ' ', depth ),
            functionName,
            args == null ?
              string.Empty :
              string.Join( ", ", Array.ConvertAll( args, i => i.ToString( ) ).ToArray( ) )
          )
        );
      }
      private static void TraceEndCall( object results = null )
      {
        Trace.WriteLine
        (
          string.Format
          (
            "{0}: {1}{2}}}",
            Thread.CurrentThread.ManagedThreadId,
            new string( ' ', depth ),
            results
          )
        );
      }
    }
