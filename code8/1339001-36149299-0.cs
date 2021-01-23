    public YourType(string tableName) { // constructor
        WhiteList.AssertValid(tableName); // throws if not allowed
        deleteCommand = $"DELETE FROM [{tableName}] WHERE id = @id; SELECT @@ROWCOUNT;";
    }
    private readonly string deleteCommand;
    public virtual void Delete(int id)
    {
        var connection = dataContext.GetDatabase().Connection;
        int count = connection.ExecuteScalar<int>(deleteCommand, new { id });
        if(count != 0) throw new DbUpdateException();
    }
