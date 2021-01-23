    public string GetLookOutList(PersonalDetail[] obj)
    {
        IResponse Lol = new LookOutList(obj);
        return Lol.Response();
    }
