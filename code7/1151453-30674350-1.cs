    class B: private A {
    public:
        // We want to expose methods 1,2,3 as public so change their accessibility
        // with the using keyword
    	using A::Method1;
    	using A::Method2;
    	using A::Method3;
    
    };
