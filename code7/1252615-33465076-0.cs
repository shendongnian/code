    private IEnumerable<Foo> CreateFooFromSelect(string sql){
       SQLiteCommand command = new SQLiteCommand(sql, sqlConnection);
       SQLiteDataReader reader = command.ExecuteReader();
       while(reader.Read()){
            yield return new Foo(reader["age"]);
       }
    }
