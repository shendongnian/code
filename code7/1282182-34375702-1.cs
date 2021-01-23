        //create connection, with a connection string
		var conn = new SqlConnection(connectionString);
		conn.Open();
		var commandText = "SELECT Ad FROM OGRENCILER WHERE OgrenciKartID=@id";
		//"using" helps in automatically disposing of the object once it's done
		using(var comm = new SqlCommand(commandText, conn)) {
			//one of the proper ways to add a parameter, which also sets the value
			comm.Parameters.Add("@id", SqlDbType.Int).Value = _kimilik;
			//the rest is correct, assuming the connection can be established and this is valid SQL (correct DB structure)
			var adId = comm.ExecuteScalar().ToString();
			adLabel.Text = adId;
		}
        conn.close();
