    var bazs = new List<Baz> {
        new Baz {
            Id = 1,
            StartDate = DateTime.Today,
            EndDate = DateTime.Today.AddMonths(1)
        },
        new Baz {
            Id = 2,
            StartDate = DateTime.Today.AddMonths(-1),
            EndDate = DateTime.Today.AddMonths(1)
        },
        new Baz {
            Id = 3,
            StartDate = DateTime.Today,
            EndDate = DateTime.Today.AddMonths(1)
        }
    };
	List<Foo> foos = new List<Foo>{
        new Foo
        {
            EmployeeId = 1,
            CompanyId = 2,
            GroupId = 3,
            Bars = new List<Bar> {
                new Bar { BazId = 1 },
                new Bar { BazId = 2 },
                new Bar { BazId = 3 }
            }
        }
    };
	var result = (from extendedBar in foos.SelectMany(f => f.Bars.Select(b => new { Bar = b, f.EmployeeId, f.CompanyId, f.GroupId }))
	              join baz in bazs
			      on extendedBar.Bar.BazId equals baz.Id
			   	  select new { extendedBar.Bar, extendedBar.EmployeeId, extendedBar.CompanyId, extendedBar.GroupId, baz.StartDate, baz.EndDate })
					.GroupBy(o => new { o.EmployeeId, o.CompanyId, o.GroupId, o.StartDate, o.EndDate })
					.Select(g => new Foo { EmployeeId = g.Key.EmployeeId, CompanyId = g.Key.CompanyId, GroupId = g.Key.GroupId, Bars = g.Select(o => o.Bar).ToList() })
				 .ToList();
