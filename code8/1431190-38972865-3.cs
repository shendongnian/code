      static void Main(string[] args) {  
        // if we have parameters...
        if (args.Length > 0) { 
          //TODO: int.TryParse is a better choice
          int port = int.Parse(args[args.Length - 1]); // ... port is the last one
          server = new TcpListener(IPAddress.Any, port);
          // Rest of the program
        }
      }
