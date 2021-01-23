    static void Main(string[] args)
    {
        MainAsync(args).Wait();
        
        Console.ReadKey();
    }
    
    static async Task MainAsync(string[] args)
    {
        Message result;
        Console.WriteLine("Sending Message...");
        result = await DoSomethingAsync();
        Console.WriteLine("Message sent...");
        Console.WrtieLine(result);
    }
    
    static async Task<Message> DoSomethingAsync()
        {
            var Bot = new Telegram.Bot.Api("my API access Token");
            return Bot.SendTextMessage("@blablavla", "test message"); // It's your last call to an async function in an async function, no need to await it here.
        }
