    public async Task SearchForSomething(params string[] keywords)
    {
        foreach (var keyword in keywords)
        {
            if (await Search(keyword))
            {
                // If we have a result, we return
                return;
            }
        }
        // If we didn't find, notify?
        NotifyNada(keywords);
    }
