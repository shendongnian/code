    public async Task StartAsync(IDialogContext context)
            {
                context.Wait(ImgCardResponse);
            }
    
            private async Task ImgCardResponse(IDialogContext context, IAwaitable<IMessageActivity> argument)
            {
                var message = await argument;
                
    			//responseMsgOnly is used to pass bot reply message
    			//responseImage is used to pass thumbnail image
                var attachment = BotButtonCard(responseMsgOnly, responseImage);
                cardMsg.Attachments.Add(attachment);
                await context.PostAsync(cardMsg);
    
               
    
            }
            private static Attachment BotButtonCard(string responseMsgOnly, string responseImage)
            {
                var heroCard = new HeroCard
                {
                    Title = "Here we go with the response",
                    Subtitle = "Subtitle goes here",
                    Text = responseMsgOnly,
                    Images = new List<CardImage>
                    {
                        new CardImage(responseImage)
                    }
                    Buttons = new List<CardAction>
                    {
                        new CardAction(ActionTypes.OpenUrl, "Your Button Label", value: "https://www.google.com")
                    }
                };
    
                return heroCard.ToAttachment();
            }
            private async Task ResumeAfterAction(IDialogContext context, IAwaitable<object> result)
            {
                context.Done(new object());
            }
