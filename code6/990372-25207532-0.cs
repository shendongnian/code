    using (var cnx = Connect()) 
        using (var cmd = CreateCommand(2)) {
             try {
                 if (cnx.State == ConnectionState.Close) cnx.Open()
                 
                 cmd.CommandTimeout = 600;
                 using (var reader = cmd.ExecuteReader(CommandBehavior.SequentialAccess)) {
                     if (reader.HasRows)
                         while (reader.Read()) {
                             // Perhaps bottleneck will disappear here...
                             // Without proper code usage of your reader
                             // no one can help.
                         }
                 }
             } catch(OracleException ex) {
                 // Log exception or whatever, otherwise might be best to let go and rethrow
             } finally {
                 if (cnx.State == ConnectionState.Open) cnx.Close();
             }
        }
