    private void DoStuff()
    {
        AppDomain.CurrentDomain.UnhandledException += HandleUnhandledException;
        var sql = new StringBuilder();
        if (updateModel.IsUseGroupNumberSelected)
        {
            AppendCommaIfNeeded(sql);
            sql.Append("GroupNumber = @p_GroupNumber");
            cmd.Parameters.AddWithValue("@p_GroupNumber", updateModel.Group.GroupNumber);
        }
        if (updateModel.IsUseTerminationDateSelected)
        {
            AppendCommaIfNeeded(sql);
            sql.Append("GroupNumber = @p_GroupNumber");
            cmd.Parameters.AddWithValue("@p_TerminationDate", updateModel.Group.TerminationDate);
        }
        if (updateModel.IsUseLocationSelected)
        {
            AppendCommaIfNeeded(sql);
            sql.Append("Location = @p_Location");
            cmd.Parameters.AddWithValue("@p_Location", updateModel.Group.Location);
        }
        sql.Insert(0, @"UPDATE [Group] SET ");
        sql.Append(" WHERE GroupID = @p_GroupID");
        cmd.Parameters.AddWithValue("@p_GroupID", updateModel.Group.GroupID);
    }
    private void AppendCommaIfNeeded(StringBuilder toBuilder)
    {
        if (toBuilder.Length > 0) toBuilder.Append(",");
    }
