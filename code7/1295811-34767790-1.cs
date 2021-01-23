    Db.Open();
    for (int i = 0; i < list.Count; i++)
    {
       command = new SqlCommand("update Login_Users set Password=@a  where UserName !='" + null + "'", Db);
       list[i] = Encrypt(list[i]);
       command.Parameters.AddWithValue("@a",list[i]);
       int a = command.ExecuteNonQuery();
    }
