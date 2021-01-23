    // You don't use "this" in the context
    // It seems, that you want to return the collected data (List<ClassList>)
    private static List<ClassList> GetClassList() {
      // Put IDisposable into using 
      using (SqlConnection conn = new SqlConnection(GlobalVar.ConnString)) {
        conn.Connect();
    
        // You want to fetch two fields only, right? Not the entire table (*)
        String sql = 
          @"select Name,
                   BirthDay
              from Class_Data"
    
        using (SqlCommand cmd = new SqlCommand(sql, conn)) {
          List<ClassList> result = new List<ClassList>();
          
          using (SqlDataReader dr = cmd.ExecuteReader()) {
            while (dr.Read()) {
              result.Add(new ClassList() {
                Name = Convert.ToString(dr[0]),
                Birthday = Convert.ToDateTime(dr[1])
              });
            }
          }  
    
          return result;  
        }  
      }
    }
