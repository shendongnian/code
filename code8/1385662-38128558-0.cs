    MessageResult messages = twilio.ListMessages(request);
    do
    {
        if (messages.Messages != null)
        {
            ... process results here
            if (messages.NextPageUri != null)
            {
                messages = twilio.GetNextPage<MessageResult>(messages);
            }
        }
    } while (messages.NextPageUri != null);
