    public override bool Equals(object obj)
    {
        OnlineProductHierarchy o = obj as OnlineProductHierarchy;
        if(o == null) return false;
        if(o.IsDefault != this.IsDefault) return false;
        if(o.IsDefault)
            return String.Compare(o.Value, this.Value, true) &&
                   String.Compare(o.TextField, this.TextField, true);
        else
            return String.Compare(o.Product, this.Product, true) &&
                   String.Compare(o.Value, this.Value, true) &&
                   String.Compare(o.TextField, this.TextField, true);
    }
    public override int GetHashCode()
    {
        if(this.IsDefault)
            return this.TextField.ToUpper().GetHashCode() ^
                   this.Value.ToUpper().GetHashCode();
        else
            return this.Product.ToUpper().GetHashCode() ^ 
                   this.TextField.ToUpper().GetHashCode() ^
                   this.Value.ToUpper().GetHashCode();
    }
