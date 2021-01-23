    public async Task ShowTextInColors(string text, int x, int y, int delay, CancellationToken token)
    {
        ConsoleColor[] colors = Enum.GetValues(typeof(ConsoleColor)).OfType<ConsoleColor>().ToArray();
        int color = -1;
        while (!token.IsCancellationRequested)
        {
            color += 1;
            if (color >= colors.Length) color = 0;
            Console.CursorLeft = x;
            Console.CursorTop = y;
            Console.ForegroundColor = colors[color];
            Console.Write(text);
            await Task.Delay(delay, token);
        }
    }
