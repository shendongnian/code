    class A {
        private Boolean isAllowedAccess;
        
        protected A(String password) {
            this.isAllowedAccess = password == "12345abc";
        }
        
        protected void Foo() {
            if( !this.isAllowedAccess ) throw new InvalidOperationException();
        }
    }
    class B : A {
        
        public B() : base("12345abc") {
        }
        
        void Bar() {
            this.Foo(); // OK
        }
    }
    class C : A {
        
        public C() : base(null) {
        }
        
        void Baz() {
            this.Foo(); // I don't want to permit this
        }
    }
