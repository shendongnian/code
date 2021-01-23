    enum ExitCode : int {
      Success = 0,
      ForceTermination = 1,
      SocketException = 2
    }
    
    System.Environment.Exit(ExitCode.ForceTerminate);
    
