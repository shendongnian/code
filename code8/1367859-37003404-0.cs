    //Set up datatable with all questions
    DataTable dt=new DataTable();
    dt.column.Add("Question",typeof(string));
    dt.column.Add("R1",typeof(string));
    dt.column.Add("R2",typeof(string));
    dt.column.Add("R3",typeof(string));
    dt.column.Add("R4",typeof(string));
    dt.column.Add("R_correct",typeof(int));
    SqlConnection con = new SqlConnection(@"Data Source=MARIA-PC;Initial Catalog=Account;Integrated Security=True");
    con.Open();
    SqlCommand cmd = new SqlCommand("SELECT * FROM [dbo].[QuestAdd] WHERE Class = '1'", con);
    SqlDataReader reader = null;
    reader = cmd.ExecuteReader();
    while (reader.Read())
    {
      DataRow dr=dt.NewRow();
      dr["Question"] = (reader["Question"].ToString());
      dr["R1"] = (reader["R1"].ToString());
      dr["R2"] = (reader["R2"].ToString());
      dr["R3"] = (reader["R3"].ToString());
      dr["R4"]  = (reader["R4"].ToString());
      dr["R_correct"]  = (reader["R_correct"]);
      dt.Rows.Add(dr);
    }
    con.Close();
