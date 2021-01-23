    public interface IFooBar<T> where T : Base
    {
        T Update(T toUpdate);
    }
    public class Foo : IFooBar<DerivedFoo>
    {
        public DerivedFoo Update(DerivedFoo toUpdate)
        {
            toUpdate.FooProperty = "X";
            return toUpdate;
        }
    }
    public class Bar : IFooBar<DerivedBar>
    {
        public DerivedBar Update(DerivedBar toUpdate)
        {
            toUpdate.BarProperty = 42;
            return toUpdate;
        }
    }
