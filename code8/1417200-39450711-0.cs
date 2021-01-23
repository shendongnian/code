    Activity reply = activity.CreateReply($"");
        reply.Recipient = activity.From;
        reply.Type = "message";
        reply.Attachments = new List<Attachment>();
        
        List<CardAction> cardButtons = new List<CardAction>();
        CardAction cityBtn1 = new CardAction()
        {
            Value = "cleveland",
            Type = "postBack",
            Title = "Cleveland"
        };
        cardButtons.Add(cityBtn1);
        
        CardAction cityBtn2 = new CardAction()
        {
            Value = "columbus",
            Type = "postBack",
            Title = "Columbus"
        };
        cardButtons.Add(cityBtn2);
        
        HeroCard plCard = new HeroCard()
        {
            Title = "Please select what city you are in?",
            Buttons = cardButtons
        };
        Attachment plAttachment = plCard.ToAttachment();
        reply.Attachments.Add(plAttachment);
