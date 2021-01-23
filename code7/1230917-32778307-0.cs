            string a = "abcd";
            string b = "bcda"; // bad daa a1b2c3 abc123
            string aa = String.Concat(a.OrderBy(c => c));
            string bb = String.Concat(b.OrderBy(c => c));
            if (aa == bb)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
