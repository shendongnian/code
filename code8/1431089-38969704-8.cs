    #define UseFooPropertery // define pre-processor symbol
       class A
       {
           [Conditional("UseFooPropertery")]
           public Foo FooProperty{get; set}
       }
