    string YourString = "str123";
    string NewString= string.Empty;
    int val;
    
    for (int i=0; i< a.Length; i++)
    {
        if (Char.IsDigit(a[i]))
            b += a[i];
    }
    
    if (b.Length>0)
        val = int.Parse(b);
