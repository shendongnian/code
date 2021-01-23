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
    abstract class D
    {
        public abstract void Fiddle();
        public virtual string Frobble() { … }
    }
    class E
    {
        public void Fiddle() { … }
        public virtual string Frobble() { … }
    }
