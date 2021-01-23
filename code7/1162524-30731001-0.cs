    [WebMethod]
    [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
    public static string SaveUser(Saved user)
    {
        string constr = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
    
            try
            {
                using (SqlCommand cmd = new SqlCommand("select count(*)from TestTable2 where Email=@Email"))
                {
    
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Email", user.Email);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
    
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    con.Close();
                    if (count > 0)
                    {
                        return new JavaScriptSerializer().Serialize(new { Message = "Email Taken"});
                    }
                    else
                    {
                        return new JavaScriptSerializer().Serialize(new { Message = "Email Inserted"});
                        
                    }
                }
    
            }
            catch (Exception E)
            {
    
                StreamWriter sw = new StreamWriter(@"C:\inetpub\wwwroot\jQuery_AJAX_Database\error.txt", true);
                sw.WriteLine(E.Message + user.Email);
    
                sw.Close();
                sw.Dispose();
    
                throw new Exception(E.Message);
                return new JavaScriptSerializer().Serialize(new { Message = "Error Occured"});
            }
        }
    }
