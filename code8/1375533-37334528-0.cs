    using (var scope = DialogModule.BeginLifetimeScope(Conversation.Container, message))
    {
         var client = scope.Resolve<IConnectorClient>();
         client.Messages.SendMessage(message);
    }
