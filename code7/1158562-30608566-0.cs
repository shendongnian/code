    private void Test(string operant)
    {
        Dictionary<string, Action> actionMap = new Dictionary<string, Action>();
        // map operant to action methods
        actionMap.Add("+", new Action(AddToken));
        actionMap.Add("-", new Action(AddToken));
        actionMap.Add("*", new Action(AddToken));
        actionMap.Add(">=", () =>
        {
            // anynomous method
            token.Add(">=");
        });
        actionMap.Add("/", new Action(Divide));
        actionMap.Add("<=", new Action(LessThanOrEqual));
        // list keep continue here
        foreach (string key in actionMap.Keys)
        {
            if (key == operant)
            {
                actionMap[key]();
            }
            
        }
    }
    private void AddToken()
    {
    }
    private void Divide()
    {
    }
    
    private void LessThanOrEqual()
    {
    }
    // .. and so on
