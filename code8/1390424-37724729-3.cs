    Outlook.MailItem MailItemRecall = (MailItem)selObject;
      if (MailItemRecall != null)
                {
                    Outlook.Action recallaction = selObject.Actions.Add();
                    recallaction.Name = "Recall This Message";
                    recallaction.MessageClass = "IPM.Outlook.Recall";
                    recallaction.ResponseStyle = OlActionResponseStyle.olSend;
                    recallaction.CopyLike = OlActionCopyLike.olReplyFolder;
                    recallaction.Execute(); 
    }
