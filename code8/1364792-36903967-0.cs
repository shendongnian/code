    public override bool Equals(object obj)
    { 
        if (obj is IntVector2)
        {
            return Equals((IntVector2)this); // <-- "this" should be "obj"
        }
    }
