    // Constructer
    public FarmActions(string token)
    {
        // set the urls using the token
        _url = new URL(token);
        // define web browser properties
        _wb = new WebBrowser();
        _wb.DocumentCompleted += PageLoaded;
        _wb.Visible = true;
        _wb.AllowNavigation = true;
        _wb.ScriptErrorsSuppressed = true;
    }
    public int Attack(int x, int y, ArmyBuilder army)
    {
        // instruct to attack the village
        _action = ENUM.FarmActions.Attack;
        //get the army and coordinates
        _army = army;
        _enemyCoordinates[X] = x;
        _enemyCoordinates[Y] = y;
            
        //Place the attack command
        _errorFlag = true; // the action is not complated, the flag will set as false once action is complete
        _attackFlag = false; // attack is not made yet
        _isAlive = true;
        Console.WriteLine("-------------------------");
        Console.WriteLine("Journey starts");
        NavigateThroughTread(_url.GetUrl(ENUM.Screens.RallyPoint));
        return _errorFlag ? -1 : CalculateDistance();
    }
    private void NavigateThroughTread(string url)
    {
        Console.WriteLine("Defining thread...");
        _wb.Navigate(url);
        while (_isAlive) Application.DoEvents();
    }
    private void PageLoaded(object sender, WebBrowserDocumentCompletedEventArgs e)
    {
        Console.WriteLine("Pages loads...");
        .
        .
        .
        switch (_action)
        {
            .
            .
            .
            case ENUM.FarmActions.Idle:
               _wb.Navigate(new Uri("about:blank"));
               _action = ENUM.FarmActions.Exit;
               return;
            case ENUM.FarmActions.Exit:
                break;
        }
        _isAlive = false;
    }
