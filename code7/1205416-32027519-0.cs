    static char[] A={'a','b','c'};
    static int N = 3;
    static void foo(string s)
    {
        if (s.Length == N)
        {
            Console.WriteLine(s);
            return;
        }
        for (int i = 0; i < A.Length; i++)
        {
            string t = s;
            t += A[i];
            foo(t);
        }
    }
