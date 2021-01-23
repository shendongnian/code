	var foos = new List<Foo>()
	{
		new Foo()
		{
			SearchId = "Y",
			GroupedPackages = new List<Foo>()
			{
				new Foo() { SearchId = "X" },
				new Foo() { SearchId = "Z" },
				new Foo()
				{
					SearchId = "W",
					GroupedPackages = new List<Foo>()
					{
						new Foo() { SearchId = "G" },
						new Foo() { SearchId = "H" },
					}
				}
			}
		}
	};
