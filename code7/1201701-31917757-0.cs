    var task1 = Task.Factory.StartNew(() =>
    {
        try
        {
            throw new MyCustomException("I'm bad, but not too bad!");
        }
        catch(Exception ex)
        {
            return new Result { Error = ex };
        }
    });
