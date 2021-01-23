    public void DoStuff (ParamObject uglyRecord)
    {
        //do stuff...
    }
    
    public void CallStuff()
    {
        ParamObject uglyRecord = new ParamObject();
        uglyRecord.Blah1 = "things";
        uglyRecord.Blah2 = DateTime.Now();
    
        DoStuff(uglyRecord);
    }
