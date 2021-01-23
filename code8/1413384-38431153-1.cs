    class Program {
        static void Main( string[] args ) {
          PrintColoredString( "First", "firstString", ConsoleColor.Green );
          PrintColoredString( "second", "secondString", ConsoleColor.Cyan );
          Console.ResetColor();
          Console.ReadKey();
        }
    
        private static void PrintColoredString(string key, string value, ConsoleColor color) {
          Console.ForegroundColor = color;
          Console.Write( "{0} {1} ", key, value );
        }
      }
