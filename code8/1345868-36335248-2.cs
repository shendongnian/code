    private void FillWinemakerComboBox()
    {
        SqlCommand cmand = new SqlCommand("SELECT (Lname+', '+Fname+' '+Mname) AS combinedName, Lname, Fname, Mname FROM Winemaker", con);
        con.Open();
        SqlDataReader sqlReader = cmand.ExecuteReader();
        Dictionary<string, string> comboSource = new Dictionary<string, string>();
        while (sqlReader.Read())
        {
            var key = String.Format("{0},{1},{2}", sqlReader["Lname"].ToString(), sqlReader["Fname"].ToString(), sqlReader["Mname"].ToString());
            comboSource.Add(key, sqlReader["combinedName"].ToString());
        }
        winemaker_comboBox.DataSource = new BindingSource(comboSource, null);
        winemaker_comboBox.DisplayMember = "Value";
        winemaker_comboBox.ValueMember = "Key";
        sqlReader.Close();
        con.Close();
    }
