    private void UpdateTeamScore(string teamName, int score) {
       using (SqlConnection con = new SqlConnection(CS)) {
          con.Open();
          using (SqlCommand command = new SqlCommand("UPDATE tblScore SET Score = @Score WHERE TeamName = @TeamName;", con)) {
             command.Parameters.Add(new SqlParameter("Score", score));
             command.Parameters.Add(new SqlParameter("TeamName", teamName));
             command.ExecuteNonQuery();
          }
       }
    }
