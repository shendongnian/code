    public T DefaultResponse<T>(string messageText)
        where T : OurBaseClass, new()
    {
        return new T
        {
            StatusMessage = messageText,
        };
    }
