    private static void Skype_MessageStatus(ChatMessage pMessage, TChatMessageStatus Status)
    {
           if (Status != TChatMessageStatus.cmsReceived) return;
        
           MessageBox.Show(pMessage.Sender.Handle + " Says: " + pMessage.Body);
    }
