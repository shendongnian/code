    public void delete(string Name)
    { 
            SqlCommand cmd = new SqlCommand("delete from clientrequest where client_name='" + Name + "'", con);
            con.Open();
            cmd.ExecuteNonQuery();
            Response.Redirect("welcome.aspx");
            con.Close();
    }
