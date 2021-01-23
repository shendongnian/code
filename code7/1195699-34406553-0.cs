    public async static Task RunStoryboard(Storyboard Story, FrameworkElement item)
    {
        Story.Begin(item);
        while (Story.GetCurrentState() == ClockState.Active && Story.GetCurrentTime() < Story.Duration)
        {
            await Task.Delay(100);
        }
    }
