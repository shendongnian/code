    public Class Action1: IAction;
    public Class Action2: IAction;
    public Class Action3: IAction;
    Dictionary<int, IAction> dict = new Dictionary<int, IAction>()
    {
        6, new Action1(); //110
        3, new Action2(); //011
        7, new Action3(); //111
    };
