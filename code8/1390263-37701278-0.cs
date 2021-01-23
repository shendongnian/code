    public interface IBasic
    {
        public void DoThing();
    }
    
    public interface IAdvanced : IBasic
    {
        public void DoAnotherThing();
        public void Thing();
    }
