        bool isMatchStr(string str1, string str2)
        {
            string s1 = str1.Replace("*", ".*?");
            string s2 = str2.Replace("*", ".*?");
            bool r1 = Regex.IsMatch(s1, "^" + s2);
            bool r2 = Regex.IsMatch(s2, "^" + s1);
            return r1 || r2;
        }
