    using(var con = new SqlConnection(conString))
    using(var cmd = con.CreateCommand())
    {
       cmd.CommandText = @"update Customer set title = @title, [Name] = @name 
                           where ID = @id";
       cmd.Paramter.Add("@title", SqlDbType.NVarChar).Value = titleComboBox2.Text;
       cmd.Paramter.Add("@name", SqlDbType.NVarChar).Value = nameTextBox2.Text;
       cmd.Paramter.Add("@id", SqlDbType.Int).Value = int.Parse(idTextBox.Text);
       // I assumed your column types.
       con.Open();
       cmd.ExecuteNonQuery();
    }
