        public static string Replace3(string input)
        {
            char[] inputCharArr = input.ToCharArray();
            List<char> lst = new List<char>();
            foreach (var c in inputCharArr)
            {
                int intC = (int)c;
                if (intC > 47 && intC < 58)
                    lst.Add((char)(intC + 8272));
                else lst.Add(c);
            }
            return new string(lst.ToArray());
        }
