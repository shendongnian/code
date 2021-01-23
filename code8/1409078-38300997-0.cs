    public TResult Handle(TQuery query)
    {
        try
        {
             var result = _handler.Handle(query);
            _log.Info("Ok");
            return result;
        }
        catch (Exception ex)
        {
            _log.Error(ex.Message, ex);                
            throw;
            // Alternatively, but unnecessarily:
            // throw ex;
        }
    }
