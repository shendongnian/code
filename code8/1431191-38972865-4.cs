      static void Main(string[] args) { 
        if (args.Length == 2) {
          //TODO: int.TryParse is a better choice 
          int option = int.Parse(args[0]);
          int port = int.Parse(args[1]);
          // Rest of the program, e.g.
          if (option == 1) {
            ...  
          } 
          else if (option == 2) {
            ...
          }
          else if (option == 3) {
            ...
          }   
        }
      }
