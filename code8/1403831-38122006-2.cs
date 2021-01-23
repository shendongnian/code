    public interface IFooBar
    {
        Base Update(Base toUpdate);
    }
    public abstract class BaseFooBar<T> : IFooBar where T : Base
    {
        protected abstract T UpdateDerived(T Base);
        public Base Update(Base toUpdate)
        {
            var derived = toUpdate as T;
            if (derived == null)
            {
                //not expected type. decide what you want to do in this case. throw exception?
            }
            return UpdateDerived(derived);
        }
    }
    public class Foo : BaseFooBar<DerivedFoo>
    {
        protected override DerivedFoo UpdateDerived(DerivedFoo toUpdate)
        {
            toUpdate.FooProperty = "X";
            return toUpdate;
        }
    }
    public class Bar : BaseFooBar<DerivedBar>
    {
        protected override DerivedBar UpdateDerived(DerivedBar toUpdate)
        {
            toUpdate.BarProperty = 42;
            return toUpdate;
        }
    }
