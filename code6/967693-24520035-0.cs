    public static string playerPrefKey_a = "a_value";
    public static int a
    {
        get { return PlayerPrefs.GetInt(playerPrefKey_a); }
        set { PlayerPrefs.SetInt(playerPrefKey_a, value); }
    }
