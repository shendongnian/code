    try
    {
        /// ...
    }
    catch (Exception ex)
    {
        if (ex is ArgumentException)
        {
            /// handle known or specific exceptions here
        }
        else 
        {
            /// log then rethrow unhandled exceptions here
            logExceptions(ex);
            throw;  
        }
    }
