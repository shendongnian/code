    public static bool IsOfType<T>(this object obj) => obj is T;
    public static bool IsOfType<T1, T2>(this object obj) => obj is T1 || obj is T2;
    public static bool IsOfType<T1, T2, T3>(this object obj) => obj is T1 || obj is T2 || obj is T3;
    public static bool IsOfType<T1, T2, T3, T4>(this object obj) => obj is T1 || obj is T2 || obj is T3 || obj is T4;
    public static bool IsOfType<T1, T2, T3, T4, T5>(this object obj) => obj is T1 || obj is T2 || obj is T3 || obj is T4 || obj is T5;
    public static bool IsOfType<T1, T2, T3, T4, T5, T6>(this object obj) => obj is T1 || obj is T2 || obj is T3 || obj is T4 || obj is T5 || obj is T6;
    public static bool IsOfType<T1, T2, T3, T4, T5, T6, T7>(this object obj) => obj is T1 || obj is T2 || obj is T3 || obj is T4 || obj is T5 || obj is T6 || obj is T7;
    public static bool IsOfType<T1, T2, T3, T4, T5, T6, T7, T8>(this object obj) => obj is T1 || obj is T2 || obj is T3 || obj is T4 || obj is T5 || obj is T6 || obj is T7 || obj is T8;
