    static void Main(string[] args)
    {
      HashSet<string> targets = new HashSet<string>( args.Select( a => new FileInfo(a).FullName ) , StringComparer.OrdinalIgnoreCase ) ;
      foreach ( Process p in Process.GetProcesses().Where( p => targets.Contains(p.MainModule.FileName) ) )
      {
        Console.WriteLine( "Killing process id '{0}' (pid={1}), main module: {2}" ,
          p.ProcessName ,
          p.Id ,
          p.MainModule.FileName
          ) ;
        try
        {
          p.Kill() ;
          Console.WriteLine("...Killed");
        }
        catch ( Exception e )
        {
          Console.WriteLine( "...well, that was unexpected. Error: {1}" , e.Message ) ;
        }
      }
      return;
    }
