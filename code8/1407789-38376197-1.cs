      static async Task GetContactPhoneNumber()
        {
            while (true)
            {
                var Updates = await Bot.GetUpdates();
                foreach (var update in Updates)
                {
                    Console.WriteLine("aaaa");
                    if (update.Type == UpdateType.MessageUpdate)
                    {
                        Console.WriteLine("bbb");
                        var cc = update.Message.Contact.PhoneNumber;
                        //string ph = message.Contact.PhoneNumber;
                        await Bot.SendTextMessageAsync(update.Message.Chat.Id, cc);
                    }
                }
            }
        }
