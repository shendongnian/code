    class Base : IBla
    {
        void IBla.DoSomething()
        {
            this.DoSomethingForIBla();
        }
        protected virtual void DoSomethingForIBla()
        {
            ...
        }
    }
    class Derived : Base
    {
        protected override void DoSomethingForIBla()
        {
            ...
        }
    }
