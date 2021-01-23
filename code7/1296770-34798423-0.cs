    public static Dictionary<string, Func<Task>> myDict= new Dictionary<string, Func<Task>>()
    {
        {"!example", () => Task.Run(() => MessageEventArgs.Channel.SendMessage("HelloWorld")) }
    }
    
    await myDict[e.Message.Text]();
