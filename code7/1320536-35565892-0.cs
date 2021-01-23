	this.DataContext = new MyViewModel
	{
		Items = new List<classC>
		{
			new classC
			{
				name = "Class C",
				subItems = new List<classB> {
					new classB{
						name = "Class B1",
						subItems = new List<classA>{
							new classA {name="Class A1a"},
							new classA {name="Class A1b"},
							new classA {name="Class A1c"},
						}
					},
					new classB{
						name = "Class B2",
						subItems = new List<classA>{
							new classA {name="Class A2a"},
							new classA {name="Class A2b"},
							new classA {name="Class A2c"},
						}
					}
				}
			}
		}
	};
