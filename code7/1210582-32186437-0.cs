    List<ELetter> ReadQueryMessages(MessageQueue queue, 
                                    MessageEnumerator enumerator, 
                                    bool removeAfterRead = true)
    {
        List<Message> messages = new List<Message>();
        while (enumerator.MoveNext(new TimeSpan(0, 0, 1)))
        {
            messages.Add(enumerator.Current);
            if (removeAfterRead)
                queue.ReceiveById(enumerator.Current.Id); 
                // enumerator.RemoveCurrent(); - this does not work properly!
        }
        // here I have 5 messages in the list - OK.
    }
