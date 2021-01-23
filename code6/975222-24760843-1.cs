    // Object.Equals()
    public bool Equals(object other)
    {
        // need to check the type of the passed in object
        MyGroup grp = other as MyGroup;
        // other is not a MyGroup
        if(grp == null return false);        
        return string.Compare(this.f1, grp.f1) == 0;
        // you could also use
        //    return this.Equals(grp);
        // as a shortcut to reuse the same "equality" logic
    }
