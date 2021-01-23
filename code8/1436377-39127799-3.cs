    public static void Register(HttpConfiguration config)
    {
       // Your existing route definiton here
       config.Filters.Add(new LangSettingActionFilter());
    }
