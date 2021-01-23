    field.GestureRecognizers.Add(new TapGestureRecognizer
    {
        Command = new Command(async () => 
        { 
                await ScollTest();
        }),
        NumberOfTapsRequired = 1,
    });
    private async void ScollTest()
    {
      // Then adjust your scroll this way.
      await scr.ScrollToAsync(100, 1000, true);
    }
