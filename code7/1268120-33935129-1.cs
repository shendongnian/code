            string s = "01234567";
            int l = s.Length;
            int c = l / 2 + 1; //center
            for (int i = 0; i < c; i++)
                Console.WriteLine(s.Substring(c - i - 1, i * 2 + 1).PadLeft(c + i, ' '));
            for (int i = c - 2; i >= 0; i--)
                Console.WriteLine(s.Substring(c - i - 1, i * 2 + 1).PadLeft(c + i, ' '));
