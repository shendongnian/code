            OleDbConnection Connection;
            Connection = new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0;Data Source=" +
                       Server.MapPath("~/db.mdb"));
            OleDbCommand Command1, Command2, Command3;
            List<OleDbCommand> commands = new List<OleDbCommand>();
            commands.Add(new OleDbCommand("SELECT a FROM Table1 WHERE ID = 1", Connection));
            commands.Add(new OleDbCommand("SELECT a FROM Table1 WHERE ID = 2", Connection));
            commands.Add(new OleDbCommand("SELECT a FROM Table1 WHERE ID = 3", Connection));
            Connection.Open();
            foreach (var command in commands)
            {
                try
                {
                    var1= (int)Command.ExecuteScalar();
                }
                catch (Exception)
                {
                      // ...
                }
            }
            Connection.Close();
