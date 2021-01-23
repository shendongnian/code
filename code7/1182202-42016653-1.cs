    public class Foo{
        public Bar Bar { get; set; }
    }
    public class Bar { }
    Expression<Func<Foo, object>> expression = p => p.Bar;
    Expression<Func<Foo, Bar>> stronglyTypedReturnValue =(Expression<Func<Foo, Bar>>) new ReturnTypeVisitor<Foo, Bar>().Visit(expression);
