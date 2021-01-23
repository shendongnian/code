    try
    {
        await transportWeb.DeliverAsync(myMessage);
    }
    catch (ErrorsException ex)
    {
        var errors = ex.Errors
    }
    classs ErrorsException : Exception
    {
        public string[] Errors { get; set; }
    }
