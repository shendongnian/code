    OutputStack<string> Output = new OutputStack<string>();
    Output.OnAdd += (sender, e) =>
    {
        if (Output.Count > 0)
        {
            var message = Output.Pop();
            actor.Tell(new LogActor.LogMessage(message));
        }
    };
