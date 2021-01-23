    public void x()
    {
        var isValidY = y();
        if (isValidY)
            z();
    }
    
    public bool y()
    {
        if(some condition) return false;
        // some code...
        return true;
    }
    
    public void z()
    {
        // some code...
    }
