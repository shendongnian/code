    public class ParamObject 
    {
        public string blah1 { get; set; }
        public DateTime blah2 { get; set; }
    }
    public void DoStuff (ParamObject uglyRecord)
    {
        //do stuff...
    }
    
    public void CallStuff()
    {
        ParamObject uglyRecord = new ParamObject();
        paramObject.Blah1 = "things";
        paramObject.Blah2 = DateTime.Now();
    
        DoStuff(ugluRecord);
    }
