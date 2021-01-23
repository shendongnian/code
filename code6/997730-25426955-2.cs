    private sealed class DatabaseDeadlockTransientErrorDetectionStrategy : ITransientErrorDetectionStrategy
    {
        public bool IsTransient(Exception ex)
        {
            var sqlException = ex as SqlException;
            if (sqlException == null)
                return false;
            return sqlException.Number == 1205;
        }
        public static readonly DatabaseDeadlockTransientErrorDetectionStrategy Instance = new DatabaseDeadlockTransientErrorDetectionStrategy();
    }
