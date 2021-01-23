    public diff(IEnumerable<Student> new, IEnumberable<Student> old)
    {
        var both = new.AddRange(old); 
        var add = both.Except(new);
        return add.Except(old);
    }
