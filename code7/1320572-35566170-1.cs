      public struct Parser
      {
         public delegate bool ParseDelegate(string content);
         public string platformName;
         public ParseDelegate d_isThisPlatform;
         public ParseDelegate d_parseAsm;
    
         public Parser(string platformName,ParseDelegate isThisPlatform, ParseDelegate parseAsm)
         {
            this.platformName = platformName;
            this.d_isThisPlatform = isThisPlatform;
            this.d_parseAsm = parseAsm;
         }
      };
