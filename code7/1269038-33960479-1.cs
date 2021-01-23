    namespace XmlParsers.Models
    {
      public static class XMLParsers
      {
        public static void ParseByXML()
        {
          A = new DataTable();
          ...
          return A;
        }
    
        public static DataTable ParseByLinq(DataTable A)
        {
          var B = from row in A 
                  ...
          return B;
        }
      }
    } 
