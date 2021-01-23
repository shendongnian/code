    public static ReplaceGarbage(String garbageString)
    {
        return garbageString.Replace(@"%3C", @"<")
                            .Replace(@"3E", @">")
                            .Replace(@"%22", @"""");
    }
