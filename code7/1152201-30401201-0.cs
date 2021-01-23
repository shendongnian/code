    protected void btnSubmitAnswer_onClick(object sender, EventArgs e)
    {
     String connectionString = "Server=root;Database=test;User=name;Password=test;";
     using (SqlConnection conn = new SqlConnection(connectionString))
     {
          SqlCommand cmd = new SqlCommand(
               "INSERT INTO Answers (QuestionID, Answer_Name, Answer)" +
               "VALUES (@prmQuestionId, @prmAnswerName, @prmAnswer)");
          cmd.Parameters.Add(new SqlParameter("@prmQuestionId", QuestionId/*HERE INSERT THE ID VALUE OF THE FETCHED QUESTION*/));
          cmd.Parameters.Add(new SqlParameter("@prmAnswerName", txtName.Text));
          cmd.Parameters.Add(new SqlParameter("@prmAnswer", txtAnswer.Text));
          cmd.Connection = conn;
          conn.Open();
          cmd.ExecuteScalar().ToString();
     }   
    }
