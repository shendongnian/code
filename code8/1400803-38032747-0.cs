    public /*unsafe*/ static string Foo(string text)
    {
        char[] a = text.ToCharArray();
        for(int i = 0; i < a.Length; i++)
            switch(a[i])
            {
            case 'A': a[i] = '_'; break;
            case 'B': a[i] = '-'; break;
            case 'C': a[i] = '+'; break;
            }
        return new string(a);
    }
