    Process self = Process.GetCurrentProcess() ;
    foreach( Process p in Process.GetProcesses().Where( p => p.Id != self.Id ) )
    {
      p.Kill() ;
    }
