           Bool first = true;
            var sql = new StringBuilder();
            sql.Append(@"UPDATE [Group] SET ");
               if (updateModel.IsUseGroupNumberSelected)
               {
                   if (!first) sql.Append(", ");
                   sql.Append("GroupNumber = @p_GroupNumber");
                   cmd.Parameters.AddWithValue("@p_GroupNumber", updateModel.Group.GroupNumber);
                   first = false;
                }
               if (updateModel.IsUseTerminationDateSelected)
               {
                   if (!first) sql.Append(", ");
                   sql.Append("TerminationDate = @p_TerminationDate");
                   cmd.Parameters.AddWithValue("@p_TerminationDate", updateModel.Group.TerminationDate);
                   first = false;
                }
               if (updateModel.IsUseLocationSelected)
               {
                    if (!first) sql.Append(", ");
                    sql.Append("Location = @p_Location");
                    cmd.Parameters.AddWithValue("@p_Location", updateModel.Group.Location);
                    first = false;
                }
              sql.Append(" WHERE GroupID = @p_GroupID");
              cmd.Parameters.AddWithValue("@p_GroupID", updateModel.Group.GroupID);
