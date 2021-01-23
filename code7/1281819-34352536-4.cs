    using(var con = new MySqlConnection(conStr))
    using(var cmd = con.CreateCommand())
    {
        cmd.CommandText = "insert into details (`name`) values(@id)";
        con.Open();
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
             cmd.Parameters.Clear();
             TextBox txtUsrId = (TextBox)GridView1.Rows[i].FindControl("txtStudent_Name");    
             cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = txtUsrId.Text;
             cmd.ExecuteNonQuery();
        }
    }
