    using(var conn = new SqlConnection(@"Data Source=QEAG1YU4664IBKF\HUYNHBAO;Initial Catalog=TonghopDB;User ID=sa;Password=koolkool7"))
    using(var cmd = conn.CreateCommand())
    {
       cmd.CommandText = "Select Title, Post from TongHopDB where Title = @title";
       cmd.Parameters.Add("@title", SqlDbType.NVarChar).Value = cboxDB.SelectedValue.ToString();
       // I assumed your column type is nvarchar.
       conn.Open();
       using(SqlDataReader sdr = cmd.ExecuteReader())
       {
          if(dr.Read())
          {
             textBox1.Text = sdr.GetValue(0).ToString();
             textBox2.Text = sdr.GetValue(1).ToString();
          }
       }
    }
