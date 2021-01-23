    public static object Load(string saveTag, object obj) {
        string temp = PlayerPrefs.GetString(saveTag);
        if (temp == string.Empty) {
            return null;
        }
    
