    public abstract class Inner
    {
    }
    public abstract class Outer<T>
        where T : Inner
    {
    }
    public abstract class Handler<TInner> // NOTE: TOuter removed
        where TInner : Inner
    {
        public abstract void SetValue(TInner value);
    }
    public class In : Inner
    {
    }
    public class Out : Outer<In>
    {
    }
    public class HandleOut : Handler<In> // NOTE: Out removed
    {
        public override void SetValue(In value) { }
    }
