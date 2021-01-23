    string strBook = wr.Target as string;
    if(strBook  != null) {
        Console.WriteLine("again -> Book is alive");
        if(string.IsInterned(strBook) != null)
            Debug.WriteLine("Because this string is interned");
    }
    else Console.WriteLine("again -> Book is dead");
