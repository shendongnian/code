    public static IEnumerable<Task> TaskGeneratorSequence()
    {
        for(int i = 0; i < 10; i++)
            yield return Task.Delay(TimeSpan.FromSeconds(2);
    }
