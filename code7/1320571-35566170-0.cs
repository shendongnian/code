      public struct Parser
      {
         public string platformName;
         public Func<string, bool> d_isThisPlatform;
         public Func<string, bool> d_parseAsm;
    
         public Parser(string platformName,Func<string, bool> isThisPlatform, Func<string, bool> parseAsm)
         {
            this.platformName = platformName;
            this.d_isThisPlatform = isThisPlatform;
            this.d_parseAsm = parseAsm;
         }
      };
