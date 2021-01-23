         string Tag = Request.QueryString["Tag"].ToString();
         SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["conStr"].ToString());
                SqlCommand cmd = new SqlCommand("FetchResaultByTag");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NewsTag",   HttpUtility.UrlDecode(Tag));
    cmd.Connection = con;
            SqlDataReader DR;
            String Txt = "";
            try
            {
                con.Open();
                DR = cmd.ExecuteReader();
                while (DR.Read())
                {
                    Txt = Txt + DR.GetString(0) + "-" + DR.GetString(1) + "-" + DR.GetString(2) + "-" + DR.GetString(3) + "/";
                }
                Response.Write(Txt);
                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();
                Response.Write(ex.ToString());
            }
