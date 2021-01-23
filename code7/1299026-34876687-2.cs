    using(var con = new SqlConnection(conStr))
    using(var cm = con.CreateCommand())
    {
       cm.CommandText = @"Select * from H_Facturi_Clienti 
                          where Serie like @serie and Numar like @numar and Data >= @data";
       cm.Parameters.Add("@serie", SqlDbType.NVarChar).Value = TextBox1.Text + "%";
       cm.Parameters.Add("@numar", SqlDbType.NVarChar).Value = textBox2.Text + "%";
       cm.Parameters.Add("@data", SqlDbType.SmallDateTime).Value = dateTimePicker1.Value;
       // Do whatever you want
    }
