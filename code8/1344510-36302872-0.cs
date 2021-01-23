     private void loadDropDownList()
        {
            componentTypeDropdown.RemoveAll();
            OleDbConnection conn = new OleDbConnection(connectionString);
            OleDbCommand cmd = new OleDbCommand("SELECT FieldName,FieldLabel FROM dropDownFields", conn);
            conn.Open();
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
               List<String> temp = new List<string>();
               temp.Add((string)dr.GetValue(0));
               temp.Add((string)dr.GetValue(1));
               componentTypeDropDown.Add(temp);
               conn.Close();
            }
        }
