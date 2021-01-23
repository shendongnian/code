    internal void RemoveDetail(Permission p)
    {
        this.RemoveDetail(p); // Makes Recursive call
        Class.RemoveDetail(this, p); // calls RemoveDetail inside Class
    }
