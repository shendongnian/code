    namespace MyBot
    {
        [LuisModel("80ba6a3b-8f62-47e6-81d0-350211b85580", "9b593fab21d54a328c0b9aeb0a64138b")]
        public MyBotClass
        {
            [LuisIntent("")]
            public async Task None(IDialogContext context, LuisResult result)
            {
                string message = "I'm sorry I didn't understand. Try asking about your bill.";
                await context.PostAsync(message);
                context.Wait(MessageReceived);
            }
        
            [LuisIntent("NextInvoiceDate")]
            public async Task NextInvoiceDate(IDialogContext context, LuisResult result)
            {
                string message = "Your next payment will go out on the 17th of the month.";
                await context.PostAsync(message);
                context.Wait(MessageReceived);
            }
        }
    }
