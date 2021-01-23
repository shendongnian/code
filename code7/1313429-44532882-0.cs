    int offset = 0;
                while (true)
                {
                    Telegram.Bot.Types.Update[] updates = bot.GetUpdates(offset).Result;
                    foreach (var update in updates)
                    {
                        offset = update.Id + 1;
                        if (update.Message == null)
                            continue;
                            
                        Console.WriteLine("Sending Message...");
                        bot.SendTextMessage(update.Message.Chat.Id, "your text");
                        Console.WriteLine("Message sent...");
                        update.Message.Text);
                    }
                }
