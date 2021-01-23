    [Fact]
    public virtual void Regex_IsMatchOptionsNone()
    {
        AssertQuery<Customer>(
            cs => cs.Where(c => Regex.IsMatch(c.CompanyName, "^A", RegexOptions.None)),
            entryCount: 4);
        Assert.Contains("WHERE \"c\".\"CompanyName\" ~ ('(?p)' || '^A')", Sql);
    }
