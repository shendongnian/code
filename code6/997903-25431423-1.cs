    double randomValue = Convert.ToDouble(txtBoxRandomValue.Text); //get value to match and convert to double
    try
        {
            conn.Open();
            OleDbCommand cmd = new OleDbCommand("SELECT A, B, C, D, E, F "+
                "FROM [SHEET1$]", conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
    
            if (randomValue == Convert.ToDouble(reader.GetValue(0))) //checking here the first column
             {
                double X = (double)reader.GetValue(1);
                double Y = (double)reader.GetValue(2);
                CreatePadFooting(X, Y);
             }
           }
        }
            catch
            {
            }
