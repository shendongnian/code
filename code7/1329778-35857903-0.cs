    try
    {
        string stmt = "SELECT SUM(case when Gender='Male' then 1 else 0 end) AS MaleCount, 
                              SUM(case when Gender='Female' then 1 else 0 end) AS FemaleCount 
                       FROM info";
        int mcount = 0;
        int fcount = 0;
        SqlConnection con = new SqlConnection(constring);
        {
            SqlCommand cmd = new SqlCommand(stmt, con);
            {
                con.Open();
                SQLDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    mcount = (int) reader["MaleCount"];
                    fcount = (int) reader["FemaleCount"];
                }
                con.Close();
            }
        }
        label1.Text = "There are " + mcount.ToString() + " Male in your database";
        label2.Text = "There are " + fcount.ToString() + " Female in your database";
    }
    catch (Exception ex)
    {
        MessageBox.Show(ex.Message);
    }
