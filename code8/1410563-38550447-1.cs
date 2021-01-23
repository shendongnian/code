    using System;
    namespace ConsoleApplication1
    {
        class Program
        {
            static string FirstN(string s, int n = 140)
            {
                if (string.IsNullOrEmpty(s) || s.Length <= n) return s;
                while (n > 0 && s[n] != ' ' && s[n] != ',') n--;
                return s.Substring(0, n);
            }
            static void Main(string[] args)
            {
                var s = FirstN("M5903, M6169, M6753, M619, M6169, M6753, M6919, M6169, M6753, M919, M6169, M6753, M6919, M6169, M6753, M6919, M6169, M6753, M919, M6169, M6753, M6919, M669, M6753, M6919, M69, M6753, M6919, M6169, M63, M6919, M6169, M6753, M6919, M619, M653, M6919, M66, M6753, M19, M6169, M6753, M6919, M6169, M6753, M6919, M6169, M6753, M6919, M6169, M6753, M619");
    
                Console.WriteLine(s.Length); // 136
                Console.WriteLine(s);  //M5903, M6169, M6753, M619, M6169, M6753, M6919, M6169, M6753, M919, M6169, M6753, M6919, M6169, M6753, M6919, M6169, M6753, M919, M6169,
            }
        }
    }
