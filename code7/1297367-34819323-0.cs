    public override bool Equals(object obj)
    {
        Temperature other = obj as Temperature;
        if (other == null) { return false; }
        return (Value == other.Value && Unit == other.Unit);
    }
