    List<int> ints = new List<int>();
    List<string> strings = new List<string>();
    foreach (object o in ints.Cast<object>().Concat(strings))
    {
        if (o is int)
        {
            // do in specific stuff
        }
        // do all my generic stuff.    
    }
