    // Class to contain the port info.
    public class PortInfo
    {
      string Name;
      string Description;
    }
    
    // Method to prepare the WMI query connection options.
    public static ConnectionOptions PrepareOptions ( )
    {
      ConnectionOptions options = new ConnectionOptions ( );
      options . ImpersonationLevel = ImpersonationLevel . Impersonate;
      options . AuthenticationLevel = AuthenticationLevel . Default;
      options . EnablePriveleges = true;
      return options;
    }
    // Method to prepare WMI query management scope.
    public static ManagementScope PrepareScope ( string machineName , ConnectionOptions options , string path  )
    {
      ManagementScope scope = new ManagementScope ( );
      scope . Path = new ManagementPath ( @"\\" + machineName + path );
      scope . Options = options;
      scope . Connect ( );
      return scope;
    }
    
    // Method to retrieve the list of all COM ports.
    public static List<PortInfo> FindComPorts ( )
    {
      List<PortInfo> portList = new List<PortInfo> ( );
      ConnectionOptions options = PrepareConnectionOptions ( );
      ManagementScope scope = ProcessConnection . PrepareScope ( Environment . MachineName , options , @"\root\CIMV2" );
      
      // Prepare the query and searcher objects.
      ObjectQuery objectQuery = new ObjectQuery ( "SELECT * FROM Win32_PnPEntity WHERE ConfigManagerErrorCode = 0" );
      ManagementObjectSearcher portSearcher = new ManagementObjectSearcher ( scope , objectQuery );
      using ( portSearcher )
      {
        string caption = null;
        // Invoke the searcher and search through each management object for a COM port.
        foreach ( ManagementObject currentObject in portSearcher . Get ( ) )
        {
          if ( currentObject != null )
          {
            object currentObjectCaption = currentObject [ "Caption" ];
            if ( currentObjectCaption != null )
            {
              caption = currentObjectCaption . ToString ( );
              if ( caption . Contains ( "(COM" ) )
              {
                PortInfo portInfo = new PortInfo ( );
                portInfo . Name = caption . Substring ( caption . LastIndexOf ( "(COM" ) ) . Replace ( "(" , string . Empty ) . Replace ( ")" , string . Empty );
                portInfo . Description = caption;
                portInfoList . Add ( portInfo );
              }
            }
          }
        }
      }
      return portInfoList;
    }
