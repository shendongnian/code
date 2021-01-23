    protected void btnmodif_Click(object sender, EventArgs e)
    {
       var wasSuccessful = UpDateDB();
       if(wasSuccessful)
       {
          //Do Something 
       }
       else
       {
         //Do Something Else logging etc...
       }
    }
    public static bool UpDateDB()
    {
    	var ConnString = System.Configuration.ConfigurationManager.ConnectionStrings["AGENDAConnectionString2"].ConnectionString;
    	bool successful = false;
    	var ddlSelectedText = DropDownList1.SelectedItem.Text;
        var strUpdate = "UPDATE RDV SET STATUES_COM = @STAT_COM WHERE INDICE = @ind"; 
    	using (SqlConnection connection = new SqlConnection(ConnString))
    	{
    		using (SqlCommand sqlComm = new SqlCommand(strUpdate, connection))
    		{
    			sqlComm.CommandType = CommandType.Text;
    			sqlComm.Parameters.AddWithValue("@STAT_COM", ddlSelectedText);
    			sqlComm.Parameters.AddWithValue("@ind", (string)Request.QueryString["Champ"]);
    			sqlComm.CommandTimeout = 120;
    			sqlComm.Connection.Open();
    			try
    			{
    				sqlComm.ExecuteNonQuery();
    				successful = true;
    			}
    			catch(SqlException SqlEx)
    			{
    				successful = false;
    				//Write to a long SqlEx.Message
    			}
    		}
    	}
    	return successful;
    }
