    string MyConnectionString = "Server=localhost;Database=smsjobs;Uid=root;pwd=root;";
    protected void Submit_Click(object sender, EventArgs e) { 
        using(var connection = new MySqlConnection(MyConnectionString)) {
            connection.Open(); 
            var cmd = connection.CreateCommand();
            cmd.CommandText="select * from userdetails where db_mobi=@username and db_pass=@word";
            cmd.Parameters.AddWithValue("@username", cn_mobi.Text);
            cmd.Parameters.AddWithValue("@word", cn_pass.Text);
            var reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                Session["id"] = cn_mobi.Text;
                Response.Redirect("Redirectform.aspx");
                Session.RemoveAll();
            }
        }
    }
