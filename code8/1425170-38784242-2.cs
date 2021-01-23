    public static DataSet SQLGetData(string connectionString, string commandString)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            DataSet DS = new DataSet();
            DataTable DT = new DataTable("Table1");
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(commandString, connection);
                //command.CommandTimeout = 3000;
                SqlDataReader read = command.ExecuteReader();
                DS.Tables.Add(DT);
                DS.Load(read, LoadOption.PreserveChanges, DS.Tables[0]);
                   
            }
            catch (SqlException e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
            }
            finally
            {
                connection.Close();
            }
            return DS;
        }
    }
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
            }
            else
            {
                command = command + " AND Tech_Area = '" + comboBox2.Text + "'";
            } 
            count = count + 1;                 
        }
        if (comboBox3.Text != "")
        {
            if (count == 0)
            {
                command = command + " WHERE LevelOf = '" + comboBox3.Text + "'";                
            }
            else
            {
                command = command + " AND LevelOf = '" + comboBox3.Text + "'";
            }
            count = count + 1;                 
        }
        // comboBox4, comboBox5, comboBox6 
        
        string ConnStr; //Connection string;
        
        DataSet DS = new DataSet();
        DataTable DT = new DataTable(); 
        DT = SQLGetData(ConnStr, Command).Tables[0];       
        DS.Tables.Add(DT);
        DataGridView1.DataSet = DS;                
    }
