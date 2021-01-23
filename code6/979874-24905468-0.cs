    // Should not be alive
    if(wr.IsAlive) {
        string t = (string)wr.Target;
        Debug.WriteLine("again -> Book is alive");
        if(string.IsInterned(t) != null)
            Debug.WriteLine("Because this string is interned");
    }
    else Debug.WriteLine("again -> Book is dead");
