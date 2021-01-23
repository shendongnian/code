    template.Render(DotLiquid.Hash.FromAnonymousObject(new
			{
				user = new User
				{
					Name = "Tim Jones",
					Tasks = new List<Task>
					{
						new Task { Name = "Documentation" },
						new Task { Name = "Code comments" }
					}
				}
			}));
