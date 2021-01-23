        private static async Task InsertIntoSqlAsync(string eventName, string email,
            string category, string url, string generalType, string reason, 
            string statusString, string attempt, string responseString,
            Guid emailDetailsGuid,int cnt)
        {
            using (
                var sqlConnection =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["CodeCampSV06"].ConnectionString))
            {
                //sqlConnection.Open();
                await sqlConnection.OpenAsync();
                const string sqlInsert =
                  @"INSERT INTO  SendGridEvent ...
                using (var sqlCommand = new SqlCommand(sqlInsert, sqlConnection))
                {
                    sqlCommand.Parameters.Add("EventName", SqlDbType.VarChar).Value = GetWithMaxLen(eventName, 60);
                    ...
                    await sqlCommand.ExecuteNonQueryAsync();
                }
            }
        }
