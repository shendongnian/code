    string connectionString = GetConnectionString();
    static private string GetConnectionString()
    {
    	return "Data Source = s59.hekko.net.pl; Initial Catalog = truex2_kuba; Integrated security=true";
    }
    
    private void druk_Click(object sender, EventArgs e)
    {
    	string queryString = "INSERT INTO [dbo].[barcode] ([ColumnNameForClassinbarcodeTable],[ColumnNameForTreeinbarcodeTable],[ColumnNameForTypeinbarcodeTable],[ColumnNameForAmountinbarcodeTable],[ColumnNameForLengthinbarcodeTable],[ColumnNameForWidthinbarcodeTable],[ColumnNameForSquareinbarcodeTable]) VALUES (@class, @tree, @type, @amount, @length, @width, @square)";
    	using (SqlConnection sqlConnection = new SqlConnection(connectionString))
    	using (SqlCommand sqlCommand = new SqlCommand(queryString, sqlConnection))
    	{
    		try
    		{
    			//This example assumes all the columns are varchar(500) in your database table design, you may
    			//likewise modify these to SqlDbType.Float, SqlDbType.DateTime etc. based on your design
    			
    			sqlCommand.Parameters.Add("@class", SqlDbType.VarChar, 500).Value = klasa.Text;
    			sqlCommand.Parameters.Add("@tree", SqlDbType.VarChar, 500).Value = gatunek.Text;
    			sqlCommand.Parameters.Add("@type", SqlDbType.VarChar, 500).Value = rodzaj.Text;
    			sqlCommand.Parameters.Add("@amount", SqlDbType.VarChar, 500).Value = amount.Text;
    			sqlCommand.Parameters.Add("@length", SqlDbType.VarChar, 500).Value = length.Text;
    			sqlCommand.Parameters.Add("@width", SqlDbType.VarChar, 500).Value = width.Text;
    			sqlCommand.Parameters.Add("@square", SqlDbType.VarChar, 500).Value = length.Text;
    						
    			sqlCommand.CommandType = CommandType.Text;
    			sqlConnection.Open();
    			int i = sqlCommand.ExecuteNonQuery();
    			sqlConnection.Close();
    
    			if (i != 0)
    			{
    				MessageBox.Show("Successful Insert.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
    			}
    
    			else
    				MessageBox.Show("Error.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    		}
    
    		catch (Exception ex)
    		{
    			MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    		}
    					
    	}
    }
