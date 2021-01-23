    public static void SendMessage<T>(string queuName, T objeto)
    {
        QueueClient Client =QueueClient.CreateFromConnectionString(connectionString, "Empresa");
        BrokeredMessage message = new BrokeredMessage(objeto);
        message.ContentType = objeto.GetType().Name;
        Client.Send(new BrokeredMessage(message));
    }
