    class RespObj {
        public string label { get; set; }
        public string value { get; set; }
    }
    
    [WebMethod]
    public static List<RespObj> Getauto(string title)
    {
        List<RespObj> result = new List<RespObj>();
        string cs = ConfigurationManager.ConnectionStrings["MyCS"].ConnectionString;
        using (SqlConnection con = new SqlConnection(cs))
        {
            SqlCommand cmd = new SqlCommand("SpMySearch", con);
            cmd.CommandType = CommandType.StoredProcedure;
            {
                con.Open();
                cmd.Parameters.AddWithValue("@SearchText", title);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    result.Add(new RespObj(){
                        label = dr["title"].ToString(),
                        value = dr["id"].ToString()
                    });
                }
                return result;
            }
        }
    }
