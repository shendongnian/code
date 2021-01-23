    interface ITest
    {
        void F();                     // F()
        void F(int x);                // F(int)
        void F(ref int x);            // F(ref int)
        ...
        int F(string s);              // F(string)
        ...
    }
