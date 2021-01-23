    namespace XmlParsers.Models
    {
      public static class XMLParsers
      {
        private static DataTable A;
    
        public static void ParseByXML()
        {
          A = new DataTable();
          ...
        }
    
        public static DataTable ParseByLinq()
        {
          var B = from row in A 
                  ...
          return B;
        }
      }
    }  
