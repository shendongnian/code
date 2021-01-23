    static string ReplaceNumber(string p, int location, string newValue)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(p);
            sb.Remove(location, 1);
            sb.Insert(location, newValue);
            return  sb.ToString();         
        }
