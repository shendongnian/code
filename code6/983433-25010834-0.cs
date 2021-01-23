     var db = EnterpriseLibraryContainer.Current.GetInstance<Database>();
     using( DbCommand command = db.GetStoredProcCommand("Your Stored proc name"))
     {
       db.AddInParameter(command, "@mydate", DbType.DateTime, DateTime.Now.Date); // Replace with MyDTP01.Value
       db.ExecuteNonQuery(command);
     }
