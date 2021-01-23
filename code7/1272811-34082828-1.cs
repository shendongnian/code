    public static bool operator ==(pl m, pl n)
    {
         return m.mark == n.mark;
    }    
    public static bool operator !=(pl m, pl n)
    {
         return !(m == n);
    }
