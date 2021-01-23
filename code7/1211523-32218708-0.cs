     public string Projects()
    {
        using (SqlConnection con = new SqlConnection(str))
        {
            string htmlStr = "";
            SqlCommand cmd = new SqlCommand("Sp_oldprojects", con);
            cmd.Parameters.AddWithValue("@AgenId", Session["AgencyId"].ToString());
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int ProjId = reader.GetInt32(0);
                string ProjTitle = reader["ProjTitle"].ToString();
                htmlStr += "<tr><td>" + ProjId + "</td>" +  ProjTitle + "<td><a href=\"OldProjView.aspx?pId=" + ProjId + "\" class=\"btn btn-small\" title=\"Detailed View\"><i class=\"icon-search\"></i></td>" + "</tr>";
            }
            reader.Close();
            return htmlStr;
        }
    }
