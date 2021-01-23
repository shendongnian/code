    public /*unsafe*/ static string Foo(string text)
    {
        char[] a = new char[text.Length];
        for(int i = 0; i < text.Length; i++)
        {
            char c=text[i];
            switch(c)
            {
            case 'A': a[i] = '_'; break;
            case 'B': a[i] = '-'; break;
            case 'C': a[i] = '+'; break;
            default: a[i] = c; break;
            }
        }
        return new string(a);
    }
