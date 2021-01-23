    private Action[] GameActions;
    public BlackJack()
    {
        this.GameActions = new [] { Action.Hit, Action.Stay };
        this.gameType = GameType.BlackJack;
        this.River = new Card[HANDSIZE];
        this.UserList = new Player[TOTALUSERS];
    }
