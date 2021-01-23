	// change your signature to async so the thread can be released during the database update/insert act
	private async Task UploadStreamAsync(string name, Stream stream) {
		
		var conn = this.context.Database.Connection; // SqlConnection from your DbContext
		if(conn.State != ConnectionState.Open)
			await conn.OpenAsync();
		using (SqlCommand cmd = new SqlCommand("UPDATE dbo.FilesForUpload SET Content =@content WHERE Name=@name;", conn)) {
			  cmd.Parameters.Add(new SqlParameter(){ParameterName = "@name",Value = name});
			  // Size is set to -1 to indicate "MAX"
			  cmd.Parameters.Add("@content", SqlDbType.Binary, -1).Value = stream;
			  // Send the data to the server asynchronously
			  await cmd.ExecuteNonQueryAsync();
		}
	}
