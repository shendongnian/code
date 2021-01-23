     string queryUpdateQuestions = @"INSERT INTO questions (.....);
                                     SELECT LAST_INSERT_ID()";
     using(MySqlCommand cmdUpdateQuestions = new MySqlCommand(queryUpdateQuestions, conn, tr))
     {
        // build the parameters for the question record
        ......
        
        // Instead of ExecuteNonQuery, run ExecuteScalar to get back the result of the last SELECT
        int lastQuestionID = Convert.ToInt32(cmdUpdateQuestions.ExecuteScalar());
        ..
     }
