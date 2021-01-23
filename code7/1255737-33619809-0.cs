    async void SomeEventHandler(object sender, EventArgsOrWhatever args)
    {
         await SomeEventHandlerAsync(sender, args);
    }
    async Task SomeEventHandlerAsync(object sender, EventArgsOrWhatever args)
    {
          ... // Actual handling logic
    }
