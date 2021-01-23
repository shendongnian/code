    abstract class FooBase<TEnum> : IFoo<TEnum>
    where TEnum : struct, IConvertible, IFormattable, IComparable {
       public TEnum MyEnum { get; set; }
    }
    public static TFooClass GetFoo<TFooClass, TEnum>()
    where TFooClass : FooBase<TEnum>, new()
    where TEnum : struct, IConvertible, IFormattable, IComparable {
       TFooClass fooclass = new TFooClass();
       return fooclass;
    }
