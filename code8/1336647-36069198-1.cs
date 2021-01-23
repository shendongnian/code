    // try name ordering
    int nameOrdering = this.Name.CompareTo(other.Name);
    
    // names not equal ⇒ ordering is clear and no need to inspect further
    if (nameOrdering != 0)
    {
        return nameOrdering;
    }
    // names are equal ⇒ resort to version ordering    
    else
    {
        return this.Version.CompareTo(other.Version);
    }
