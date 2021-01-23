    public static class EntityCommandExecutionExceptionExtensions
    {
        public static bool IsInvalidObjectNameError(
            this EntityCommandExecutionException exception)
        {
            const int InvalidObjectName = 208;
            var sqlException = exception.InnerException as SqlException;
            if (sqlException == null)
            {
                return false;
            }
            return sqlException.Errors.Cast<SqlError>().Any(
                error => error.Number == InvalidObjectName);
        }
    }
