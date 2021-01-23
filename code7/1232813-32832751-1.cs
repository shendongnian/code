    class Class2 : Class1 {
        public override void Method(BaseClass e) {
            ChildClass child = e as ChildClass;
            if( child == null ) base.Method( e );
            else {
                // logic for ChildClass here
            }
        }
    }
