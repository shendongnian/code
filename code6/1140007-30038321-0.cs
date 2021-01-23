    class Base<T> : T
    {
        public override string Frobble()
        {
            Fiddle();
            return "*" + base.Frobble() + "*";
        }
    }
    class A
    {
        public sealed string Frobble() { … }
    }
    class B
    {
    }
    class C
    {
        public virtual string Frobble() { … }
    }
    class D
    {
        public void Fiddle();
        public virtual string Frobble() { … }
    }
