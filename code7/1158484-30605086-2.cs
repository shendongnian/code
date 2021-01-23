    [Test]
    public void Testing()
    {
        var list = new List<Foo>
                       {
                           new Foo { CompanyId = 1, Data = 15, Id = 1, SampleId = 2 },
                           new Foo { CompanyId = 1, Data = 10, Id = 2, SampleId = 4 },
                           new Foo { CompanyId = 1, Data = 25, Id = 3, SampleId = 8 },
                           new Foo { CompanyId = 1, Data = 25, Id = 4, SampleId = 12 },
                           new Foo { CompanyId = 1, Data = 25, Id = 5, SampleId = 14 }
                       };
        var filterList = new List<int> { 2, 4, 6 };
        var output = list.Where(l => filterList.Contains(l.SampleId))
            .GroupBy(l => l.CompanyId, (key, data) => new Bar { CompanyId = key, Data = data.Sum(d => d.Data) });
        Assert.True(output != null);
        Assert.True(output.FirstOrDefault() != null);
        Assert.True(output.FirstOrDefault().Data == 25);
    }
