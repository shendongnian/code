	public static class Extensions
	{
		public static IEnumerable<TDestination> ConvertTo<TFrom, TDestination>(this IEnumerable<TFrom> fromCollection, Func<TFrom, TDestination> expression)
		{
			List<TDestination> destinationList = new List<TDestination>();
			foreach (var element in fromCollection)
			{
				destinationList.Add(expression.Invoke(element));
			}
			
			return destinationList;
		
		}
	}
	void Main()
	{
		List<Foo> foos = new List<Foo>
		{
			new Foo { Name = "Fu" },
			new Foo { Name = "Foe" },
			new Foo { Name = "Thumb" }
		};
		
		IEnumerable<Bar> customBars = foos.ConvertTo(foo => new Bar
		{
			BarId = foo.Id,
			Name = foo.Name
		});
		
	}
