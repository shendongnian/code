	var userImage = imageToByte(img);
	
	OpenConnection();
	
	var command = new MySqlCommand("", conn);
	
	command.CommandText = "UPDATE User SET UserImage = @userImage WHERE UserID = @userId;";
	
	var paramUserImage = new MySqlParameter("@userImage", MySqlDbType.Blob, userImage.Length);
	var paramUserId = new MySqlParameter("@userId", MySqlDbType.VarChar, 256);	
	paramUserImage.Value = userImage;
	paramUserId.Value = UserID.globalUserID;	
	command.Parameters.Add(paramUserImage);
	command.Parameters.Add(paramUserId);
	command.ExecuteNonQuery();	
	
	CloseConnection();
