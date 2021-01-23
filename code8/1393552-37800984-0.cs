    private async void Foo()
    {
        while(ShouldKeepLooping())
        {
            SendKeys.Send(keyToSend);
            await Task.Delay(timespan.FromSeconds(2));
        }
    }
