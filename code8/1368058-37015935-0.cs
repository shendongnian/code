                var reply = context.MakeMessage();
                reply.Attachments = new List<Attachment>();
                var actions = new List<Microsoft.Bot.Connector.Action>();
                for (int i = 0; i < 3; i++)
                {
                    actions.Add(new Microsoft.Bot.Connector.Action
                    {
                        Title = $"Button:{i}",
                        Message = $"Action:{i}"
                    });
                }
                reply.Attachments.Add(new Attachment
                {
                    Title = "Choose one:",
                    Actions = actions
                });
                await context.PostAsync(reply);
