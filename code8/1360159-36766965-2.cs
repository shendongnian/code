    [Flags]
    public enum Setting
    {
        Setting1 = 1,
        Setting2 = 2,
        Setting3 = 4,
        Setting4 = 8
    }
    private Setting GetSetting()
    {
        Setting foo =  Setting.Setting1 | Setting.Setting2 | Setting.Setting3;
        return foo;
    }
