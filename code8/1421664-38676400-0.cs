    public override bool Equals(object o)
    {
       if(o == null)
           return false;
       var second = o as Pair<T1>;
    
       return First == second.First;
    }
    public override int GetHashCode()
    {
        return First;
    }
