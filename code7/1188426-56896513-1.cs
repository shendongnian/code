    public void SomeDbWork() {
        // ... code to create/edit/update/delete entities goes here ...
        try { Context.SaveChanges(); }
        catch (DbUpdateException e) { throw HandleDbUpdateException(e); }
    }
    public Exception HandleDbUpdateException(DbUpdateException e)
    {
        // handle specific inner exceptions...
        if (e.InnerException is System.Data.SqlClient.SqlException ie)
            return HandleSqlException(ie);
        return e; // or, return the generic error
    }
    public Exception HandleSqlException(System.Data.SqlClient.SqlException e)
    {
        // handle specific error codes...
        if (e.Number == 2601) return new DuplicateKeyRowException(e);
        return e; // or, return the generic error
    }
