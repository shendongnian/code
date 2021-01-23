    replyActivity.Attachments = new List<Attachment>();
    var cardButtons = new List<CardAction>();
    var plButton = new CardAction
    {
        Value = auth.SessionUrl,
        Type = "signin",
        Title = "Connect"
    };
    cardButtons.Add(plButton);
    var plCard = new SigninCard("You need to authorize to use Quick Book feature", cardButtons);
    var plAttachment = plCard.ToAttachment();
    replyActivity.Attachments.Add(plAttachment);
    replyActivity.Text = "Should go to conversation, sign-in card";
