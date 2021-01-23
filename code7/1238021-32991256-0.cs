    public static myEnum GetEnumName(string str)
    {
        switch(str)
        {
            case "alias_1": return myEnum.Value_1;
            case "alias_2": return myEnum.Value_2;
            default: throw new Exception();
        }
    }
