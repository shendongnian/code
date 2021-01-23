        StringBuilder sqlBuilder = new StringBuilder();
		sqlBuilder.Append(@"INSERT INTO News_Tbl(NewsCode, NewsStatus, NewsDate)");
		sqlBuilder.Append("VALUES (@NewsCode, @NewsStatus, @NewsDate); SELECT CAST(SCOPE_IDENTITY() as int)");
		
		var firstCommand = new SqlCommand(sqlBuilder, dbConn);
		firstCommand.Parameters.AddWithValue("@NewsCode", n.NewsCode);
		firstCommand.Parameters.AddWithValue("@NewsStatus", n.NewsStatus);
		firstCommand.Parameters.AddWithValue("@NewsDate", n.NewsDate);
		
		// add the first query here, an example may be:
        var lastModifiedId = command.ExecuteScalar(sqlBuilder);
		if (id != null)
		{
			sqlBuilder.Length = 0;
			sqlBuilder.Append("INSERT INTO NewsDtl_Tbl(NewsId,DetailName,Details) ");
			sqlBuilder.Append("VALUES (@lastModifiedId, @DetailName, @Details)");
			
			var secondCommand = new SqlCommand(sqlBuilder, dbConn);
			secondCommand.Parameters.AddWithValue("@lastModifiedId", lastModifiedId);
			secondCommand.Parameters.AddWithValue("@DetailName", n.DetailName);
			secondCommand.Parameters.AddWithValue("@Details", n.Details);
			secondCommand.ExecuteNonQuery();
		}
