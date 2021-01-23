    string DatabasePath = "<Your Path to your database>";
    string commandstring = "SELECT * FROM elements";
    using (SQLiteCommand MyCommand = new SQLiteCommand(commandstring, Connection))
     {
            using (SQLiteDataReader MyReader = MyCommand.ExecuteReader())
               {
                        while (MyReader.Read())
                        {
     // Here is your result:
     // You can do anything that you want with it.
     // The 0 shows the first column. If your result returns more than one      column, //you can use other numbers like 1,2..n to get other columns out of your data //reader.
                            MyReader.GetString(0);
                        }
               }
}`
