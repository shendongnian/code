	using System;
	using System.Collections.Generic;
	using System.Linq;
	
	public class Map
	{
		public string Name { get; set; }
		public IEnumerable<MapProperty> Properties { get; set; }
	}
	
	public class MapProperty
	{
		public string Name { get; set; }
	}
	
	public class Test
	{
		public static IEnumerable<Map> Merge(IEnumerable<Map> a, IEnumerable<Map> b)
		{
			return a.Concat(b)
				.GroupBy(map => map.Name)
				.Select(mg => new Map
				{
					Name = mg.Key,
					Properties = mg.SelectMany(v => v.Properties)
						.GroupBy(p => p.Name)
						.Select(pg => new MapProperty { Name = pg.Key })
				});
		}
	
		public static void Main()
		{
			var mapsA = new[]
			{
				new Map
				{
					Name = "MapA",
					Properties = new[]
					{
						new MapProperty { Name = "Jumps" },
						new MapProperty { Name = "Hops" },
					}
				},
				new Map
				{
					Name = "MapB",
					Properties = new[]
					{
						new MapProperty { Name = "Jumps" },
						new MapProperty { Name = "Skips" },
					}
				}
			};
			var mapsB = new[]
			{
				new Map
				{
					Name = "MapA",
					Properties = new[]
					{
						new MapProperty { Name = "Jumps" },
						new MapProperty { Name = "Times" },
					}
				},
				new Map
				{
					Name = "MapC",
					Properties = new[]
					{
						new MapProperty { Name = "Jumps" },
						new MapProperty { Name = "Skips" },
					}
				}
			};
			
			var mapsC = Merge(mapsA, mapsB);
			
			foreach (var map in mapsC)
			{
				Console.WriteLine($"{map.Name}");
				foreach (var prop in map.Properties)
				{
					Console.WriteLine($"\t{prop.Name}");
				}
			}
		}
	}
