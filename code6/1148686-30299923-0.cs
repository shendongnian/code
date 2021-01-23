    public class A { public virtual bool Foo (X bar) { ... } }
    public class B { 
        public override bool Foo (X bar) {
             if(bar is Y) { ... } 
             else base.Foo(bar);
        }
    }
