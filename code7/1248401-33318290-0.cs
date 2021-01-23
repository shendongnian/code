    protected void btnAuctionInfo_Click(object sender, EventArgs e)
    {
        try
        {
    	    //Put Disposable resources in "using" blocks to automatically handle clean up.
    		//Assign connection to command in the constructor
            using(System.Data.SqlClient.SqlConnection sqlConnection1 = new System.Data.SqlClient.SqlConnection("Data Source=Reshani;Initial Catalog=JKPLC;Integrated Security=True"))
            using(System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(sqlConnection1))
    		{
    			cmd.CommandType = System.Data.CommandType.Text;
    			//Do not use any quotes around parameters.
    			cmd.CommandText = @"INSERT into [Auction_Details] (year,sale_no,sale_Date,lot_no,quantity_sold,value,buyer_name,sample_id,broker_id) VALUES(@year,@sale_no,@Sale_date,@lot_no,@lot_no_quantity,@value,@buyer_name,null,null)";
    	        
    			//Create parameters
    			//SqlDbType is assumed, only you know what data type your parameters are so alter accordingly
    			SqlParameter p_year = new SqlParameter("@year", SqlDbType.SmallInt);
    			//Set parameter value. Only you know where this value comes from. You can't run the INSERT without assigning values to parameters.
    			p_year.Value = 2000;
    			//Add eaach parameter to the command
    			cmd.Parameters.Add(p_year);
    			
    			//Add the other 6 parameters here.....
    			
    			sqlConnection1.Open();
    			cmd.ExecuteNonQuery();
    			
    			//the proper way to Redirect in Asp.Net
    			Response.Redirect("homeforStaff.aspx.cs", false);
    			Context.ApplicationInstance.CompleteRequest();
            }
        }
        catch (Exception ex)
        {
            //Exception objects have a reasonably good ToString overload
            //so make it easy on yourself and just use it.
            Response.Write("Error :" + ex.ToString());
        }
    }
