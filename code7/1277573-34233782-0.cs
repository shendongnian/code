    private void LoadMammalsStringList()
    {
        _mammalsList = new List<string>();
        using (SqlConnection con = new SqlConnection(PlatypusUtils.DuckbillConnStr))
        {
            using (SqlCommand cmd = new SqlCommand(PlatypusUtils.SelectMammalIdQuery, con))
            {
                cmd.CommandType = CommandType.Text;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    foreach (DataRow row in dt.Rows)
                    {
                        _mammalsList.Add(row.ItemArray[0].ToString());
                    }
                }
            }
        }
    }
