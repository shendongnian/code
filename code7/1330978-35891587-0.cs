    [NoAutomaticTrigger]
    public async static Task DoJobNow(string value, TextWriter log)
    {
        await log.WriteLineAsync("Write with textwriter");
        await log.WriteLineAsync("Write with textwriter again - still open");
        await Task.Delay(100);
        await log.WriteLineAsync("TextWriter is closed?? Exception here!");
    }
