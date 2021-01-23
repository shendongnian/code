    using System;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string s = "123412341234";
                string Token = "2";
                var Values = new string[] {"a","b", "c" };
                int i = 0;
                int MarkerPos;
                do
                {
                    s = ReplaceFirst(s, Token, Values[i]);
                    MarkerPos = s.IndexOf(Token);
                    i++;
                } while(MarkerPos != -1 && i <= Values.GetUpperBound(0));
                Console.WriteLine(s);
                Console.ReadKey();
            }
            static string ReplaceFirst(string text, string search, string replace)
            {
                int pos = text.IndexOf(search);
                if (pos < 0)
                {
                    return text;
                }
                return text.Substring(0, pos) + replace + text.Substring(pos + search.Length);
            }
        }
    }
