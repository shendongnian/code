    public static async Task RunAsync() 
    {
        for(int i = 0; i < 5; i++) {
            await getSessionAsync ();
        }
        await doMoreStuff();
    }
