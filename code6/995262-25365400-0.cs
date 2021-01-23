    private static string GetRFIDComPort()
    {
      string portName = "";
      for ( int i = 1; i <= 20; i++ )
      {
        try
        {
          using ( SerialPort port = new SerialPort( string.Format( "COM{0}", i ) ) )
          {
            // Try to Open the port
            port.Open();
            
            // Ensure that you're communicating with the correct device (Some logic to test that it's your device)
            // Close the port
            port.Close();
          }
        }
        catch ( Exception ex )
        {
          Console.WriteLine( ex.Message );
        }
      }
      return portName;
    }
