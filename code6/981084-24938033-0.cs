    List<object> list = new List<object>();
    list.AddRange(ints);
    list.AddRange(strings);
    
    foreach(object o in list )
    {
        if(o is int)
        {
            // do in specific stuff
        }
    
        // do all my generic stuff.    
    }
