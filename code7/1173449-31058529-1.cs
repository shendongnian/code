    public void TestMethod1()
    {
        var q1 = Amazings().Where(x => x.Name.Equals("Kasa"));
        Expression predicate = q1.Expression;
        var q2 = Amazings();
        IQueryable<Amazing> q3 = q2.Provider.CreateQuery<Amazing>(predicate);
    }
    private IQueryable<Amazing> Amazings()
    {
        var amazings = new List<Amazing>
        {
            new Amazing
                {
                    Name = "Kasa",
                },
            new Amazing
                {
                    Name = "Ma@p2a"
                }
        };
        return amazings.AsQueryable();
    }
