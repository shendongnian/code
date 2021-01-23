    async void TestMethod1()
    {
        TimeTableDBConnector.DbConnector connector = new DbConnector(null);
        var getEntryByIDCommand = new GetEntryByIDCommand(1);
        ICommand result;
        try
        {
            await connector.ExecuteCommandAsync(getEntryByIDCommand, ContinueWith );
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
