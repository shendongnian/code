    class ConsultaDB {
      private static Dictionary<String, String> s_Data = new
        Dictionary<String, String>();
    
      private static void CoreFeedCache() {
        using (OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=CCPP.accdb")) {
          using (var comm = conn.CreateCommand()) {
            comm.CommandText = 
              @"select ID,
                       CP
                  from CP";
    
            using (reader = comm.ExecuteReader()) {
              while (reader.Read()) {
                s_Data.Add(Convert.ToString(reader[0]), Convert.ToString(reader[1]));
              }  
            }
          }
        }
      } 
    
      static {
        CoreFeedCache();
      }
    
      public static string returnCP(string id) {
        String result;
    
        if (!s_Data.TryGetValue(id, out result))
          result = null;
    
        return result;
      } 
    }
