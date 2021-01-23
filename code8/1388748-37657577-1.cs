    public Class1 Add(Class1 other)
    {
        if (other == null) { throw new ArgumentNullException("other"); }
        var output = new Class1(this.PropA + other.PropA, this.PropB + other.PropB);
        return output;
    }
