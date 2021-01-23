        // Making up this pseudo code
        GameApi gameApi = (GameApi)hardwareAsm.GetType(GameApi).GetMethod("Initialize").Invoke();
        TheGame gameWorld = gameApi.CreateGame(...);
        gameWorld.ResolutionChanged += Resolution_Changed(...);
        gameWorld.Terminated += Terminated(...);
        gameWorld.KeyDown += Key_Down(...);
        // etc....
        gameWorld.Start();
    
