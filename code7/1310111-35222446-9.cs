    public void DoStuff(string text, Func<string, string> textFormatter = null)
    {
        // We'll give a default formatter if none is provided ;)
        if(textFormatter == null)
          textFormatter = text => $"<span>{text}</span>";
        Console.WriteLine(textFormatter(text));
    }
