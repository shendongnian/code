    public void skype_MessageStatus(ChatMessage msg, TChatMessageStatus status)
    {
        if (msg.Body.IndexOf(trigger) == 0 && TChatMessageStatus.cmsReceived == status)
        {
            string command = msg.Body.Remove(0, trigger.Length).ToLower();
            var splitted = command.Split(new [] { ' ' }, 2);
            var command1 = new ChatCommand(splitted[0], splitted[1])
            msg.Chat.SendMessage(nick + ProcessCommand(command1));
        }
    }
