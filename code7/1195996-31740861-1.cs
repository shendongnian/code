    var json = "...."; // one of your json string
    var obj = Newtonsoft.Json.JsonConvert.DeserializeObject<TelegramBoApiMainObject>(json);
        var chat = obj.result[0].message.chat;
        if (String.IsNullOrEmpty(chat.title))
        {
            // user
        }
        else 
        {
            // group chat
        }
