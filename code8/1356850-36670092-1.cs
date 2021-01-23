    private void loadRecipe()
	{
		SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\v11.0; AttachDbFilename=C:\Users\Donald\Documents\Visual Studio 2013\Projects\DesktopApplication\DesktopApplication\Student_CB.mdf ;Integrated Security=True");
		try
		{
			//Fetching top recipe     
			string query = ("SELECT * Recipe_ID, Recipe_Name FROM Recipe");
			SqlCommand cmd = new SqlCommand(query, conn);
			cmd.Connection = conn;
			cmd.Connection.Open();
			String body;
			SqlDataReader dr = cmd.ExecuteReader();
			int count = 0;
			if(dr.HasRows){
				while(dr.Read()){
					body += count++ + " " + dr["Body"].ToString() + "<br />";  
			  }
			}
			myLabel.Text = body;
		}
		catch (Exception){}
		conn.Close();
	}
