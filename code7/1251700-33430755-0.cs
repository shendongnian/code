    public List<User> GetAll()
    {
        List<User> result = new List<User>();
        try
        {
            result _businessLogic.GetAll();
        }
        catch (Exception ex)
        {
            ExceptionHelper.HandleException(ex, _logger, ControllerContext);
        }
        return result;
    }
