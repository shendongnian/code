    public static implicit operator XLangMessage(Class obj)
    {
        XLangMessage x = new XLangMessage();
        // write conversion here
        x.Prop = obj.Prop;
        return x;
    }
