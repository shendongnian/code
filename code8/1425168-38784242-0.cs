    private void SetFilter()
    {
        string command = "SELECT * FROM Store";
        
        int count = 0;
        
        if (comboBox1.Text != "")
        {
            command = command + " WHERE GroupN = '" + comboBox1.Text + "'";
            count = count + 1; 
        }
        
        if (comboBox2.Text != "")
        {
            if (count == 0)
            {
                command = command + " WHERE Tech_Area = '" + comboBox2.Text + "'";
                count = count + 1;
            }
            else
            {
                command = command + " AND Tech_Area = '" + comboBox2.Text + "'";
            }                  
        }
        if (comboBox3.Text != "")
        {
            if (count == 0)
            {
                command = command + " WHERE LevelOf = '" + comboBox3.Text + "'";
                count = count + 1;
            }
            else
            {
                command = command + " AND LevelOf = '" + comboBox3.Text + "'";
            }                 
        }
        // comboBox4, comboBox5, comboBox6 
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(command);
        da.Fill(dt);
        DataGridView1.DataSet = dt;       
    }
