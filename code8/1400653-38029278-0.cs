    using(var conn = new SqlConnection(conString))
    using(var sq = conn.CreateCommand())
    {
       sq.CommandText = @"update Hodor_data 
                          set leaving_time = @leaving
                          where mil_no = @milno 
                          and times = (select max(times) from Hodor_data )";
       sq.Parameters.Add("@leaving", SqlDbType.DateTime).Value = dateTimePicker1.Value;
       sq.Parameters.Add("@milno", SqlDbType.Int).Value = int.Parse(textBox1.Text);
    
       conn.Open();
       sq.ExecuteNonQuery();
    }
