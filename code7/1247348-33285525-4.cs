    public sealed FooFactory<TEnum>
    where TEnum : struct, IConvertible, IFormattable, IComparable {
       public static TFooClass GetFoo<TFooClass>()
       where TFooClass : FooBase<TEnum>, new() {
          TFooClass fooclass = new TFooClass();
          return fooclass;
       }
    }
    ...
    var factory = new FooFactory<SomeEnum>();
    var foo1 = factory.GetFoo<SomeFooClass1>();
    var foo2 = factory.GetFoo<SomeFooClass2>();
    // or the other way:
    var factory = new FooFactory<SomeFooClass>();
    var foo1 = factory.GetFoo<SomeEnum1>();
    var foo2 = factory.GetFoo<SomeEnum2>();
