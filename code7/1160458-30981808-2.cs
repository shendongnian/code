    db = DatabaseFactory.CreateDatabase();
    using (DbCommand cmd = db.GetStoredProcCommand("Sp_Candidate"))
    {
        db.AddInParameter(cmd, "@candidateid", DbType.Int32, txtCandidateID.text);
        cmd.Parameters.Add(new SqlParameter("candidateSkillSets", candidateSkillSets) { SqlDbType = SqlDbType.Structured });
        db.ExecuteNonQuery(cmd);
    }
