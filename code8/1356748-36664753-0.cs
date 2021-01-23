    Exception MakeException(bool DoThrow, string Message)
    {
        if(DoThrow)
        {
            if(string.IsNullOrWhiteSpace(Message)
                 return new Exception("Message Missing");
            else
                 return new Exception(Message);
        }         
        return null;
    }
    void Main()
    {
        var ex = MakeException(true,"MyMessage");
        if(ex != null)
           throw ex;
    }
