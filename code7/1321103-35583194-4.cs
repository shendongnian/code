    Type[] parsers =
      {
         typeof(PIC32MX_GCC_Parser),
         typeof(M16C_IAR_Parser)
      };
    
      public Type findTheRightParser(string asmFileContents)
      {
         foreach(Type parser in parsers)
         {
            // You probably want to cache this
            var mi = parser.GetMethod("isThisPlatform", BindingFlags.Static);
            if ((Boolean)mi.Invoke(null, new object[] {asmFileContents}))
            {
               Console.WriteLine("Using parser: ", parser.platformName);
               return parser;
            }
         }
         return null;
      }
