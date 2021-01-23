    private static int kills = 0;
    public static int Kills
    {
        get
        {
            return kills;
        }
        set
        {
            this.kills = value;
            this.OnVarChange();
        }
    }
