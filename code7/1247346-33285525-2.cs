    abstract class FooBase {
    }
    abstract class FooBase<TEnum> : FooBase, IFoo<TEnum>
    where TEnum : struct, IConvertible, IFormattable, IComparable {
       public TEnum MyEnum { get; set; }
    }
    public static TFooClass GetFoo<TFooClass>()
    where TFooClass : FooBase, new() {
       TFooClass fooclass = new TFooClass();
       return fooclass;
    }
