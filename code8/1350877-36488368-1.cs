        public string replace(string input)
        {
            StringBuilder sb = new StringBuilder();
            Dictionary<char, char> map = new Dictionary<char, char>();
            map.Add('2', '₂');
            map.Add('3', '₃');
            map.Add('4', '₄');
            map.Add('5', '₅');
            map.Add('6', '₆');
            map.Add('7', '₇');
            char tmp;
            foreach(char c in input)
            {
                if (map.TryGetValue(c, out tmp))
                    sb.Append(tmp);
                else
                    sb.Append(c);
            }
            return sb.ToString();
        }
