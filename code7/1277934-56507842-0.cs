      int offset = 0;
                while (true)
                {
                TryAgain:
                      try{
                    Telegram.Bot.Types.Update[] updates = bot.GetUpdates(offset).Result;
                    foreach (var update in updates)
                    {
    .. . . .. 
    }
    }
        
         catch (Exception ef)
                {
                    Debug.WriteLine(ef.Message);
                    if (ef.Message.Contains("Telegram.Bot.Types"))
                    {
                        goto TryAgain; 
                    }
                }  
