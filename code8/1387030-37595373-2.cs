    public override int GetHashCode()
    {
        // Title is a string
        return Title != null ? Title.GetHashCode() : 0;
    }
