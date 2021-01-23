    string conString = "Data Source=localhost;Initial Catalog=SuperCalc;Integrated Security=True";
    using(var con = new SqlConnection(conString))
    using(var com = con.CreateCommand())
    {
        com.CommandText = @"select sum (Cost) as JameKol From TBL_Cost 
                            Where CostDate between @date1 and @date2";
        com.Parameters.Add("@date1", SqlDbType.DateTime2).Value = DateTime.Parse(textBox1.Text);
        com.Parameters.Add("@date2", SqlDbType.DateTime2).Value = DateTime.Parse(textBox2.Text);
        con.Open();
        label5.Text = com.ExecuteScalar().ToString();
    }
