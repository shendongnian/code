    using(var sqlConnection1 = new SqlConnection(conStr))
    using(var cm = sqlConnection1.CreateCommand())
    {
       cm.CommandText = "Select * from H_Facturi_Clienti where Serie like @serie and Numar like @numar and Data >= @data";
       cm.Parameters.Add("@serie", SqlDbType.NVarChar).Value = TextBox1.Text + "%";
       cm.Parameters.Add("@numar", SqlDbType.NVarChar).Value = textBox2.Text + "%";
       cm.Parameters.Add("@data", SqlDbType.SmallDatetime).Value = dateTimePicker1.Value;
       // Do whatever you want
    }
