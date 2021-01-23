    int MyFunc(string txtboxtext)
    {
        var x8 = int.Parse(txtboxtext);
                        if (x8 > 0)
                        {
                            SqlConnection cn = new SqlConnection("Data Source=.;Initial Catalog=database;Integrated Security=True");
                            SqlCommand cmd = new SqlCommand();
                            cmd.Connection = cn;
                            cmd.CommandText = "INSERT INTO tbltable " + "(id, name, value , date, iid) " + "VALUES(@id, @name, @value, @date, @iid )";
                            cmd.Parameters.AddWithValue("@id", v2);
                            cmd.Parameters.AddWithValue("@name", "10*100");
                            cmd.Parameters.AddWithValue("@value", x8);
                            cmd.Parameters.AddWithValue("@date", tarikh);
                            cmd.Parameters.AddWithValue("@iid", xxiid);
                            cn.Open();
                            cmd.ExecuteNonQuery();
                            cn.Close();
                       }
        }
