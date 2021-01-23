	using System.Data;
	using System.Data.SqlClient;
	....
	string sql = @"INSERT UserActivity (CalendarDate, ProjectId, Login, ActivityTypeId, Cost)
					VALUES (@CalendarDate, @ProjectId, @Login, 0, @Cost);";
					
	foreach (var s in days)
	{
		using (var connection = new SqlConnection(strQuery))
		using (var command = new SqlCommand(sql, connection))
		{
			command.Parameters.Add("@CalendarDate", SqlDbType.DateTime).Value = new DateTime(iYear, iMonth, int.Parse(values[1]));
			command.Parameters.Add("@ProjectID", SqlDbType.Int).Value = iProjectid;
			command.Parameters.Add("@Login", SqlDbType.VarChar, 50).Value = sLogin;
			command.Parameters.Add("@Cost", SqlDbType.Money).Value = datas[i++];
			
			connection.Open();
			command.ExecuteNonQuery();
		}
	}
