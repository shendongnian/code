    public interface IBasic
    {
        void DoThing();
    }
    
    public interface IAdvanced : IBasic
    {
        void DoAnotherThing();
        void Thing();
    }
