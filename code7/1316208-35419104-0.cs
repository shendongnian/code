    public class myClassObj
    {
        public string aProperty {get;}
    }
    public class DecoratedClassObj : myClassObj
    {
        public anotherClassObj OtherObj { get { return this.getOtherObj(); } }
    }
