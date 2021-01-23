    var Bot = new Api("YourApiToken");
    .
    .
    .
    
    var rkm = new ReplyKeyboardMarkup();
    
    rkm.Keyboard = 
        new KeyboardButton[][]
        {
            new KeyboardButton[]
            {
                new KeyboardButton("1-1"),
                new KeyboardButton("1-2")
            },
            new KeyboardButton[]
            {
                new KeyboardButton("2")
            },
            new KeyboardButton[]
            {
                new KeyboardButton("3-1"),
                new KeyboardButton("3-2"),
                new KeyboardButton("3-3")
            }
        };
    
    await Bot.SendTextMessage(update.Message.Chat.Id, msg, false, false, 0, rkm );
