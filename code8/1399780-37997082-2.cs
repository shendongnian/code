    public interface IDoStuffPublically
    {
        void DoSomething();
    }
    interface IDoStuffInternally
    {
        void DoSomething();
        void DoSomethingInternally();
    }
    class DoStuff : IDoStuffPublically, IDoStuffInternally
    {
        public void DoSomething()
        {
            // ...
        }
        public void DoSomethingInternally()
        {
            // ...
        }
    }
