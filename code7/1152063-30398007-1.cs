    public void ProcessObject(MessageDTO message)
    {
        if (functions.ContainsKey(message.Name))
        {
            functions[name](message.Parameters);
        }
    }
