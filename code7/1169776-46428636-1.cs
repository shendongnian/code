    namespace StackOverflow
    {
        class Program
        {
            static void Main(string[] args)
            {
                SteamBot bot = new SteamBot("botname", "password");
            
                while(true)
                {
                    if(bot.isReady)
                    {
                        bot.WaitForCallbacks();
                    }
                }
            }
        }
    }
