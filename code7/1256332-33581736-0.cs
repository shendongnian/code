    using (SqlConnection con = new SqlConnection(CS)) {
        con.Open();
        // Create one string with all the updates in it... 
        string query = string.Format("UPDATE tblScore SET Score={0} WHERE TeamName='{1}'; ", lblScoreA.Text, lblTeamA.Text);
        query += string.Format("UPDATE tblScore SET Score={0} WHERE TeamName='{1}'; ", lblScoreB.Text, lblTeamB.Text);
        query += string.Format("UPDATE tblScore SET Score={0} WHERE TeamName='{1}'; ", lblScoreC.Text, lblTeamC.Text);
        SqlCommand cmd = new SqlCommand(query, con);
        cmd.ExecuteNonQuery();
        }
