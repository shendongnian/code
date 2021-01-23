    static void Main()
    {            
      var dependency = GetCorrectDataParser();
      dependency.Run()
    }
        
        private static IDataParser GetCorrectDataParser()
         {
        
            try
              {
               var classToCreate = ConfigurationManager.AppSettings["DataParserName"];
               var type = Type.GetType(classToCreate);
                if (type == null) return null;
            
               var dependency = (IDataParser) Activator.CreateInstance(type);
                return dependency;
               }
           catch (Exception ex)
           { throw ex;}
               return null;
          }
