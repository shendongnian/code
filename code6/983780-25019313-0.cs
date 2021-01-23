    public static bool ReadKey(GamePrefs.Key k, bool defaultValue)
    {
        return PlayerPrefs.GetInt(k.ToString(), defaultValue ? 1 : 0) == 1;
    }
    
    public static int ReadKey(GamePrefs.Key k, int defaultValue)
    {
        return PlayerPrefs.GetInt(k.ToString(), defaultValue);
    }
    
    public static float ReadKey(GamePrefs.Key k, float defaultValue)
    {
        return PlayerPrefs.GetFloat(k.ToString(), defaultValue);
    }
    
    public static string ReadKey(GamePrefs.Key k, string defaultValue)
    {
        return PlayerPrefs.GetString(k.ToString(), defaultValue);
    }
