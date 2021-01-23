    using(var connection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
    using(var myCommand = connection1.CreateCommand())
    {
         myCommand.CommandText = @"UPDATE Modules SET UserID = @userid 
                                   WHERE ModuleID = @moduleid";
         myCommand.Parameters.Add("@userid", SqlDbType.NVarChar).Value = SearchUser;   
         myCommand.Parameters.Add("@moduleid", SqlDbType.NVarChar).Value = Module;
         // I assumed your column types are nvarchar
         connection1.Open();
         myCommand.ExecutenonQuery();
         // move on to home page
         Response.Redirect("APMDefault.aspx");
    }
