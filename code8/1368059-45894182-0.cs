            var actions = new List<CardAction>();
            for (int i = 0; i < 3; i++)
            {
                actions.Add(new CardAction
                {
                    Title = $"Button:{i}",
                    Text = $"Action:{i}"
                });
            }
            reply.Attachments.Add(
                new HeroCard
                {
                    Title = "Choose option",
                    Buttons = actions
                }.ToAttachment()
            );
             
            await context.PostAsync(reply);
