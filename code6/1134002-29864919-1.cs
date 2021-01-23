    public TResult Handle(TCommand command) {
        DateTime startTime = DateTime.Now;
        Exception exception = null;
        try {
            return _innerHandler.Handle(command);
        }
        catch (Exception ex) {
            exception = ex;
            throw;
        }
        finally {
            _requestLogger.Log(command, startTime, exception);
        }
    }
