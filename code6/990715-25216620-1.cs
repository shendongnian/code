        String strConnection = "Data Source=HP\\SQLEXPRESS;database=your_db;Integrated Security=true";
 
        SqlConnection con = new SqlConnection(strConnection);
        try
        {
 
            con.Open();
 
            SqlCommand sqlCmd = new SqlCommand();
 
            sqlCmd.Connection = con;
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "Select table_name from information_schema.tables";
 
            SqlDataAdapter sqlDataAdap = new SqlDataAdapter(sqlCmd);
 
            DataTable dtRecord = new DataTable();
            sqlDataAdap.Fill(dtRecord);
            comboBox1.DataSource = dtRecord;
            comboBox1.DisplayMember = "TABLE_NAME";
            con.Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
