    class X {}
    class Y
    {
        public static implicit operator X (Y y)
        {
            return new X();
        }
        
        public static implicit operator Y (X x)
        {
            return new Y();
        }
    }
    // and then:
    bool conversionExists = HasImplicitConversion(typeof(Y), typeof(X));
