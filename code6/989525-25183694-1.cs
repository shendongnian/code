    public override bool Equals(object obj)
    {
        OnlineProductHierarchy o = obj as OnlineProductHierarchy;
        if(o == null) return false;
        return (String.Compare(o.Product, this.Product, true) &&
               String.Compare(o.Value, this.Value, true) &&
               String.Compare(o.TextField, this.TextField, true))
               ||
               (o.IsDefault == this.Isdefault &&
               String.Compare(o.Value, this.Value, true) &&
               String.Compare(o.TextField, this.TextField, true));
    }
    public override int GetHashCode()
    {
        //Not possible using your logic
    }
