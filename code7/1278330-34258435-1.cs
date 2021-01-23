    public void x()
    {
        if (y())
        {
            z();
        }
    }
    
    // Return true if processing should continue.
    //
    public bool y()
    {
        if(some condition) return false;
        some code...
        return true;
    }
    
    public void z()
    {
        somecode...
    }
