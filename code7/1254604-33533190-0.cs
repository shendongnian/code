    public void With(Action<IDbConnection> do){
        using (var connecion = CreateConnection()){
            do(connection);
        }
    }
