    ...		
    public static void LogUserDetail()
    {
       //Get current logged on username
       string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
       using (SqlConnection conn = DBUtility.Connection)
       {
          using (SqlCommand cmd = conn.CreateCommand())
          {
             cmd.CommandText = "LogUserDetail";
             cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.Add(new SqlParameter("UserName", userName));
             cmd.Parameters.Add(new SqlParameter("DateTime", DateTime.Now));
             conn.Open();
             cmd.ExecuteNonQuery();
          }
        }
     }
