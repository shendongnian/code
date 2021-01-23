	//create connection, with a connection string
	using(var conn = new SqlConnection(connectionString)) {
		try {
			conn.Open();
		}
		catch(Exception ex) {
			//Handle exception
		}
		if(conn.State == System.Data.ConnectionState.Open) {
			var commandText = "SELECT Ad FROM OGRENCILER WHERE OgrenciKartID=@id";
			//"using" helps in automatically disposing of the object once it's done
			using(var comm = new SqlCommand(commandText, conn)) {
				//one of the proper ways to add a parameter, which also sets the value
				comm.Parameters.Add("@id", SqlDbType.Int).Value = _kimilik;
				//the rest is correct, assuming the connection can be established and this is valid SQL (correct DB structure)
				object result = null;
				try {
					result = comm.ExecuteScalar();
				}
				catch(Exception ex) {
					//handle exception
				}
				if(result != null) {
					var adId = result.ToString();
					adLabel.Text = adId;
				}
			}
			conn.Close();
		}
	}
