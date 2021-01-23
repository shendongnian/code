    public abstract class BaseClass<TClass> where TClass : BaseClass<TClass>, new()
    {
        public int Foo {get;set;}
        public virtual TClass Clone()
        {
            var clone = new TClass();
            clone.Foo = this.Foo;
            return clone;
        }
    }
    public class DerivedClass : BaseClass<DerivedClass>
    {
        public int Bar {get;set;}
        public override DerivedClass Clone()
        {
            var clone = base.ColoneInternal();
            clone.Bar = this.Bar;
            return clone;
        }
    }
