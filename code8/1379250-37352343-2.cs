    public static List<string> GetAllMonitorNames()
    {
        List<string> result = new List<string>();
        foreach (Screen scr in Screen.AllScreens)
        {
            result.Add(scr.DeviceName);
        }
        return result;
    }
