    public static int HashString(string str)
    {
       if(string.IsNullOrEmpty(str)) return 0;
       return str.ToCharArray().Sum(c => (int)c) % 10;
    }
