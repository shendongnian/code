    public static class MyClass
    {
        public static void MyMethod()
        {
    #if UNITY_EDITOR
            DoX();
    #elif UNITY_WSA
            DoY();
    #elif UNITY_IOS
            DoZ();
    #else
            DoWhatever();
    #endif
        }
    }
