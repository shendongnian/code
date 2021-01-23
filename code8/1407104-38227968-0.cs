    public abstract class BaseClass : IMyInterface<BaseFoo>
    {
        public virtual void SomeMethod(BaseFoo t)
        {
            t.CommonProperty = 1;
        }
    }
    public class ConcreteClass1 : BaseClass
    {
        public override void SomeMethod(BaseFoo t)
        {
            if(t == null)
                throw new ArgumentNullException(nameof(t));
            var foo1 = t as Foo1;
            if(foo1 == null)
                throw new NotSupportedException($"{nameof(ConcreteClass1)} does not support types other than {nameof(Foo1)}");
            foo1.SomeProperty = 57;
            base.SomeMethod(foo1);
        }
    }
    public class ConcreteClass2 : BaseClass
    {
        public override void SomeMethod(BaseFoo t)
        {
            if (t == null)
                throw new ArgumentNullException(nameof(t));
            var foo2 = t as Foo2;
            if (foo2 == null)
                throw new NotSupportedException($"{nameof(ConcreteClass2)} does not support types other than {nameof(Foo2)}");
            foo2.AnotherProperty = 123;
            base.SomeMethod(foo2);
        }
    }
    public static class ConcreteClassFactory
    {
        public enum ConcreteClassType
        {
            ConcreteClass1,
            ConcreteClass2
        }
        public static BaseClass CreateClass(ConcreteClassType type)
        {
            BaseClass toReturn = null;
            switch (type)
            {
                case ConcreteClassType.ConcreteClass1:
                    toReturn = new ConcreteClass1();
                    break;
                case ConcreteClassType.ConcreteClass2:
                    toReturn = new ConcreteClass2();
                    break;
                default:
                    break;
            }
            return toReturn;
        }
    }
