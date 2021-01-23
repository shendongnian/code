        public static class Sql
            {
        
         public static AuthenticationModel Login(string userName, string password)
                {
                    DataTable dt = GetResponseTable("Select UserID,Password from User where userName=" + userName);
                    AuthenticationModel details = new AuthenticationModel{LoginStatus = "Failed"};
                    if(dt..Rows.Count > 0 )
                      details = new AuthenticationModel{ LoginStatus = "Success", UserName = userName, UserId = dt["UserID"].toString();
        
                    return details;
                }
    
    private static DataTable GetResponseTable(string StoredProcedureName)
            {
                SqlConnection Con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
    
                DataTable dt = new DataTable();
                Con.Open();
                SqlCommand cmd = new SqlCommand(StoredProcedureName, Con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                Con.Close();
                return dt;
            }
    
        }
