    var builder = new StringBuilder(str.Length * 3); // Pre-allocate to worse-case scenario
    foreach(char c in str)
    {
       if (c >= '0' && c <= '9')
         builder.Append(c);
       else if ((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z'))
         builder.Append((int)c);
    }
    string result = builder.ToString();
