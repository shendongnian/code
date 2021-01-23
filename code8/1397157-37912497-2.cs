    private void button1_Click(object sender, EventArgs e)
    {
        string constring = "Data Source = localhost; port = 3306; username = root; password = 0159";
        // Prepare a string where you insert parameter's placeholders instead of
        // concatenating the grid values....
        string Query = @"Update TopShineDB.Table1 set CarColorNumber = @CarColorNumber, Interior = @Interior, 
                         Exterior = @Exterior , CPlastic = @CPlastic, MPlastic = @MPlastic, SPlastic = @SPlastic, 
                         PlasticB = @PlasticB, WashExt = @WashExt, WashEng = @WashEng, WashTrunk = @WashTrunk, 
                         WashSeats = @WashSeats, SeatsRmv = @SeatsRmv, SeatsFit = @SeatsFit, Notes = @Notes 
                         where `Time` = @Time";  
         
        // Using statement around connection and command to destroy
        // these objects at the end of the using block               
        using(MySqlConnection conn = new MySqlConnection(constring))
        using(MySqlCommand command = new MySqlCommand(Query, conn))
        {
            conn.Open();
            // Create the list of parameters required by the query
            // Notice that you should use the appropriate MySqlDbType
            // for the field receiving the value.
            command.Parameters.Add("@Time", MySqlDbType.VarChar); 
            command.Parameters.Add("@CarColorNumber", MySqlDbType.VarChar);
            
            ..... create all the other parameters leaving the value null
            
            try
            {
                
                foreach(DataGridViewRow dr in dataGridView1.Rows)
                {
                    // Inside the loop update the parameters' values
                    // with data extracted by the current row...
                    command.Parameters["@Time"].Value = dr.Cells[0].Value; 
                    command.Parameters["@CarColorNumber"].Value = dr.Cells[1].Value;
                
                     ..... set the value for all other parameters ....
                    
                    // ExecuteNonQuery for INSERT/UPDATE/DELETE, 
                    // ExecuteReader works but it is specific for reading
                    command.ExecuteNonQuery();		
    	        }
    	    }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }	
     }
