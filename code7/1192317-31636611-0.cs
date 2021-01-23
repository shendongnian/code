    void myFunction(string t) {
        myFunctionImpl(t, new Type[0]);
    }
    void myFunction<T0>(string t) where T0:IMyInterface {
        myFunctionImpl(t, new[] { typeof(T0) });
    }
    void myFunction<T0,T1>(string t) where T0:IMyInterface,
                                           T1:IMyInterface {
        myFunctionImpl(t, new[] { typeof(T0), typeof(T1) });
    }
    ...
    void myFunction<T0,T1,T2,T3,T4,T5,T6,T7,T8,T9>(string t)
        where T0:IMyInterface,
              T1:IMyInterface,
              T2:IMyInterface,
              T3:IMyInterface,
              T4:IMyInterface,
              T5:IMyInterface,
              T6:IMyInterface,
              T7:IMyInterface,
              T8:IMyInterface,
              T9:IMyInterface {
        myFunctionImpl(t, new[] { typeof(T0), typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9) });
    }
