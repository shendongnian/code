    public void DoIt( IA x )
    {  
        DoIt(x as T);
    }
    void DoIt( T y )
    {
        if (y == null)
            return;
        // do it
    }
