    [TestMethod]
    public void TestMethod1()
    {
        StaticDataLibrary library = StaticDataLibrary.Current;
        var people = library.GetList<Person>("people.csv");
        var grandparents = people
            .Where(p => p.ParentId == null)
            .Select(gp => new GrandParent()
            {
                Id = gp.Id,
                Name = gp.Name,
                Children = people
                    .Where(c => c.ParentId == gp.Id)
                    .Select(c => new Person()
                    {
                        Id = c.Id,
                        Name = c.Name
                    }).ToList()
            })
            .ToList();
        Mock<IDataAccess> dataAccess = new Mock<IDataAccess>();
        dataAccess.Setup(m => m.GetGrandParents())
            .Returns(grandparents);
        // invoke the method that uses the data and make assertions...
    }
