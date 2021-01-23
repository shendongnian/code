    	if (expireData)
	{
		cmd = new OracleCommand("DELETE FROM Sessions " +
								"WHERE SessionId = :SessionId AND ApplicationName = :ApplicationName", conn);
		cmd.Parameters.Add("SessionId", OracleDbType.Varchar2, 80).Value = id;
		cmd.Parameters.Add("ApplicationName", OracleDbType.Varchar2, 255).Value = ApplicationName;
		cmd.ExecuteNonQuery();
		throw new HttpException((int)HttpStatusCode.Unauthorized, "Error session, not authorized");
		context.Response.End();
	}
