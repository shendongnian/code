    static void Insert(MyPoco myPoco)
    {
        string sql = "INSERT INTO MyTable (Field1, Field2) VALUES (@Field1, @Field2)";
        bool connAlreadyOpen = (_connection.State == System.Data.ConnectionState.Open);
        if (!connAlreadyOpen)
        {
            _connection.Open();
        }
        _connection.Execute(sql, new {myPoco.Field1, myPoco.Field2});
        myPoco.ID = _connection.Query<int>("SELECT @@IDENTITY").Single();
        if (!connAlreadyOpen)
        {
            _connection.Close();
        }
        return;  // (myPoco now contains ID that is created by database.)
    }
