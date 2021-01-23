    public class PassWordClass{
    	public string Password {set; get;}
    }
    
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public PassWordClass Auth(string username)
    {
        string password = "";
        using (SqlConnection con = new SqlConnection(GetConnectionString()))
        {
            SqlCommand cmd = new SqlCommand("Select PASSWORD from users where USERNAME = '" + username + "'", con);
    
            //Open Connection
            con.Open();
    
            //To Read From SQL Server
            SqlDataReader dr = cmd.ExecuteReader();
    
            while (dr.Read())
            {
    	        var pass = new PassWordClass();
                pass.Password = dr["PASSWORD"].ToString();
    	        return pass;
            }
        }
    }
