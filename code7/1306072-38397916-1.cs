    private void LogException(Exception error, HttpContext context)
    {
      try
      {
        var connectionStr = Configuration["ConnectionString"];
        using (var connection = new System.Data.SqlClient.SqlConnection(connectionStr))
        {
          var command = connection.CreateCommand();
          command.CommandText = @"INSERT INTO ErrorLog (Application, Host, Type, Source, Path, Method, Message, StackTrace, [User],  WhenOccured)
        VALUES (@Application, @Host, @Type, @Source, @Path, @Method, @Message, @StackTrace, @User,  @WhenOccured)";
          connection.Open();
          if (error.InnerException != null)
            error = error.InnerException;
          command.Parameters.AddWithValue("@Application", this.GetType().Namespace);
          command.Parameters.AddWithValue("@Host", Environment.MachineName);
          command.Parameters.AddWithValue("@Type", error.GetType().FullName);
          command.Parameters.AddWithValue("@Source", error.Source);
          command.Parameters.AddWithValue("@Path", context.Request.Path.Value);
          command.Parameters.AddWithValue("@Method", context.Request.Method);
          command.Parameters.AddWithValue("@Message", error.Message);
          command.Parameters.AddWithValue("@StackTrace", error.StackTrace);
          var user = context.User.Identity?.Name;
          if (user == null)
            command.Parameters.AddWithValue("@User", DBNull.Value);
          else
            command.Parameters.AddWithValue("@User", user);
          command.Parameters.AddWithValue("@WhenOccured", DateTime.Now);
          command.ExecuteNonQuery();
        }
      }
      catch { }
    }
