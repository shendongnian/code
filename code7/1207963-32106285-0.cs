    public void Installer( string command, string arguments, string logFile )
    {
      var outputText = new StringBuilder( );
      var errorText = new StringBuilder( );
      var startInfo = new ProcessStartInfo( command, arguments )
      {
        CreateNoWindow = true,
        ErrorDialog = false,
        RedirectStandardError = true,
        RedirectStandardOutput = true,
        UseShellExecute = false
      };
      using ( var psexec = new Process( ) )
      {
        psexec.StartInfo = startInfo;
        psexec.OutputDataReceived += ( _, dat ) => outputText.AppendLine( dat.Data );
        psexec.ErrorDataReceived += ( _, dat ) => errorText.AppendLine( dat.Data );
        psexec.Start( );
        psexec.BeginOutputReadLine( );
        psexec.BeginErrorReadLine( );
        psexec.WaitForExit( );
        File.AppendAllText( logFile, outputText.ToString( ) );
      }
    }
