    public void Load_Combo(string Query, ComboBox cb)
    {
        string ConnectionString = @"Data Source=.\sqlexpress;AttachDbFilename=|DataDirectory|\mydatabase.mdf;user id = sa;password = 1111111111";
    
        SqlConnection connection = new SqlConnection();
    
        cb.Items.Clear();
    
        connection.ConnectionString = ConnectionString;
        connection.Open();
    
        SqlDataAdapter adaptor = new SqlDataAdapter(Query, connection);
        DataTable dtt = new DataTable();
        adaptor.Fill(dtt);
    
        for (int i = 0; i < dtt.Rows.Count; i++)
            cb.Items.Add(string.Format("{0}-{1}", dtt.Rows[i][0], dtt.Rows[i][1]));
        }       
    
        connection.Close();
    }
    
    
    private void btn1_Click(object sender, EventArgs e)
    {
       Load_Combo("SELECT ID , FName + ' ' + LName AS Fullname FROM studentstbl", cmb_cash1);
    }
