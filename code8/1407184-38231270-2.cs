    command.CommandText = "INSERT INTO mytable (id, nickname) VALUES (@id, @nickname)";
    SqlParameter[] parameters = new SqlParameter[2];
    parameters[0] = new SqlParameter("@id", SqlDbType.Int) { Value = Convert.ToInt16(txt_ID.Text) };
    parameters[1] = new SqlParameter("@nickname", SqlDbType.VarChar, 50) { Value = txt_Nickname.Text };
    command.Parameters.AddRange(parameters);
