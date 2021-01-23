	for ( var Answer in Answers )
        {
            await this._Conn.OpenAsync();
            using (SqlCommand cmd = new SqlCommand("AddOrUpdateAnswer", this._Conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AnswerVal", Answer.AnswerVal);
                cmd.Parameters.AddWithValue("@QuestionId", Answer.QuestionId);
                cmd.Parameters.AddWithValue("@PartnerId", Answer.PartnerId);
                await cmd.ExecuteNonQueryAsync();
            }
            this._Conn.Close();
        }
