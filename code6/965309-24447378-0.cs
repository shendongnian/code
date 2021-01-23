    public Test(params object[] values)
    {
         this.Values = values
                .Select((x, idx) => new {x, idx})
                .GroupBy(g => g.idx/2)
                .Select(g => new TestData(g.First().x.ToString(), (bool) g.Last().x))
                .ToArray();
    }
