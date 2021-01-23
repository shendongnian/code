    private async Task invokeActions()
    {
        foreach (Action step in listOfMethods)
        {
            step.Invoke();
            await test.WhenClicked();
        }
    }
