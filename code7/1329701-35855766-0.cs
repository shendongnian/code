        string aoi = comboBox1.Text;
        string comp = comboBox2.Text;
        string sql;
        if (aoi == "Area Of Interest" && comp == "Company")
        {
            sql = @"SELECT * FROM JobListInfo WHERE AreaOfInterest Is Not NULL AND Company Is Not NULL";
        }
        else if(....)
        {
            sql =............................
        }
        else
        {
            sql = @"SELECT * FROM JobListIn WHERE AreaOfInterest = @AOI AND Company = @Company";
        }
        cmd.CommandText = sql;
        cmd.Parameters.AddWithValue("@AOI", aoi);
        cmd.Parameters.AddWithValue("@Company", comp);
