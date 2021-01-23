    var command = new SqlCommand("update Login_Users set Password=@a  where UserName !='" + null + "'", Db);
    Db.Open();
    command.Parameters.Add(new SqlParameter("@a",null));
    for (int i = 0; i < list.Count; i++)
    {
        cmd.Parameters["@a"].Value = Encrypt(list[i]);
        int a = command.ExecuteNonQuery();
    }
