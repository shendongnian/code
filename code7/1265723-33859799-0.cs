    private SqlException CreateSqlException(string message)
    {
            var collectionConstructor = typeof(SqlErrorCollection).GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, //visibility
                null, //binder
                new Type[0],
                null);          
            var errorCollection = (SqlErrorCollection)collectionConstructor.Invoke(null);
            var constructor = typeof(SqlException).GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, //visibility
                null, //binder
                new[] { typeof(string), typeof(SqlErrorCollection), typeof(Exception), typeof(Guid) },
                null); //param modifiers
            return (SqlException)constructor.Invoke(new object[] { message, errorCollection, new DataException(), Guid.NewGuid() });
    }
