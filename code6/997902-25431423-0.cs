    int randomValue = Convert.ToInt32(txtBoxRandomValue.Text);
        OleDbDataReader reader = new OleDbDataReader();
        
        while(reader.Read())
        {
            if (randomValue == Convert.ToInt32(reader[0].ToString()))
            {
                String aa = reader[1].ToString();
                String bb = reader[2].ToString();
                //...
            }
            else
            {
                //do something here
            }
        }
