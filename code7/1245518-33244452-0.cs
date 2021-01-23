            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();
            using (SqlCommand cmd = conn.CreateCommand())
            {
                SqlParameter p = new SqlParameter("@DT", SqlDbType.Structured);
                p.Value = dt;
                p.TypeName = "dbo.typeQuestionSort";
                cmd.Parameters.Add(p);
                cmd.CommandType = CommandType.Text;
                cmd.CommandText =
                    "UPDATE tblVQuestions"
                    + " SET [SortOrder] = typeSortOrder"
                    + " FROM @DT"
                    + " WHERE QuestionID = typeQuestionID AND PID = 12 AND SID = 12"
                    + " BEGIN TRY"
                    + " DROP TYPE dbo.typeQuestionSort"
                    + " END TRY"
                    + " BEGIN CATCH"
                    + " END CATCH";
                cmd.ExecuteNonQuery();
            }
